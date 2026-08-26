using System.Runtime.CompilerServices;
using Omr.Engine;
using Omr.Engine.Geometry;
using Omr.Engine.Results;
using Omr.Engine.Templates;
using SkiaSharp;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

namespace Omr.Pdf;

public sealed class PdfOmrProcessor : IDisposable
{
    private readonly OmrProcessor _engine;
    private bool _disposed;

    public PdfOmrProcessor(OmrProcessor? engine = null)
    {
        _engine = engine ?? new OmrProcessor();
        OwnsEngine = engine is null;
    }

    private bool OwnsEngine { get; }

    public async IAsyncEnumerable<OmrPageResult> RecognizeAsync(
        string pdfPath,
        ITemplateResolver templateResolver,
        IBarcodeDecoder? barcodeDecoder = null,
        PdfOmrOptions? options = null,
        IProgress<OmrProgress>? progress = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await using FileStream stream = new(pdfPath, FileMode.Open, FileAccess.Read, FileShare.Read);
        await foreach (OmrPageResult page in RecognizeAsync(stream, templateResolver, barcodeDecoder, options, progress, cancellationToken))
        {
            yield return page;
        }
    }

    public async IAsyncEnumerable<OmrPageResult> RecognizeAsync(
        Stream pdfStream,
        ITemplateResolver templateResolver,
        IBarcodeDecoder? barcodeDecoder = null,
        PdfOmrOptions? options = null,
        IProgress<OmrProgress>? progress = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        PdfOmrOptions pdfOptions = options ?? new PdfOmrOptions();

        PdfLoadedDocument? document = TryLoadDocument(pdfStream, out OmrPageResult? loadFailure);
        if (document is null)
        {
            yield return loadFailure!;
            yield break;
        }

        using (document)
        {
            int pageCount = document.Pages.Count;
            if (pageCount <= 0)
            {
                yield return OmrPageResult.Failed(0, WorkflowFailureReasons.PdfUnsupported, "The PDF has no pages.");
                yield break;
            }

            int start = pdfOptions.StartPageIndex ?? 0;
            int end = pdfOptions.EndPageIndexInclusive ?? (pageCount - 1);
            start = Math.Clamp(start, 0, pageCount - 1);
            end = Math.Clamp(end, start, pageCount - 1);

            int completed = 0;
            for (int pageIndex = start; pageIndex <= end; pageIndex++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                OmrPageResult result = ProcessPage(
                    document,
                    pageIndex,
                    templateResolver,
                    barcodeDecoder,
                    pdfOptions);

                completed++;
                progress?.Report(new OmrProgress
                {
                    PageIndex = pageIndex,
                    PagesCompleted = completed,
                    Status = result.PageStatus
                });

                yield return result;
                await Task.Yield();

                if (pdfOptions.FailFast && result.PageStatus == PageStatus.Failed)
                {
                    yield break;
                }
            }
        }
    }

    private OmrPageResult ProcessPage(
        PdfLoadedDocument document,
        int pageIndex,
        ITemplateResolver templateResolver,
        IBarcodeDecoder? barcodeDecoder,
        PdfOmrOptions pdfOptions)
    {
        SKBitmap bitmap;
        try
        {
            bitmap = PdfPageRasterizer.Rasterize(document, pageIndex, pdfOptions);
        }
        catch (Exception ex)
        {
            return OmrPageResult.Failed(pageIndex, WorkflowFailureReasons.PageRenderFailed, ex.Message);
        }

        using (bitmap)
        {
            string? qr = null;
            if (barcodeDecoder is not null)
            {
                qr = barcodeDecoder.Decode(bitmap, crop: null);
                if (qr is null && pdfOptions.FallbackTemplate?.BarcodeRegion is { } region)
                {
                    AffineTransform identity = AffineTransform.Identity(bitmap.Width, bitmap.Height);
                    qr = barcodeDecoder.Decode(bitmap, identity.MapRect(region.Rect));
                }
            }

            if (pdfOptions.RequireQr && barcodeDecoder is not null && string.IsNullOrWhiteSpace(qr))
            {
                return OmrPageResult.Failed(pageIndex, WorkflowFailureReasons.QrCodeUnreadable, "No QR code could be decoded on this page.");
            }

            OmrTemplate? template = templateResolver.Resolve(qr) ?? pdfOptions.FallbackTemplate;
            if (template is null)
            {
                return OmrPageResult.Failed(
                    pageIndex,
                    WorkflowFailureReasons.TemplateNotFound,
                    "No OMR template is registered for this page.",
                    decodedQrValue: qr);
            }

            return _engine.Recognize(bitmap, template, pageIndex, qr);
        }
    }

    private static PdfLoadedDocument? TryLoadDocument(Stream pdfStream, out OmrPageResult? failure)
    {
        try
        {
            Stream seekable = pdfStream;
            if (!pdfStream.CanSeek)
            {
                MemoryStream copy = new();
                pdfStream.CopyTo(copy);
                copy.Position = 0;
                seekable = copy;
            }
            else
            {
                pdfStream.Position = 0;
            }

            failure = null;
            return new PdfLoadedDocument(seekable);
        }
        catch (Exception ex) when (IsPasswordError(ex))
        {
            failure = OmrPageResult.Failed(0, WorkflowFailureReasons.PdfPasswordProtected, ex.Message);
            return null;
        }
        catch (Exception ex)
        {
            failure = OmrPageResult.Failed(0, WorkflowFailureReasons.PdfCorrupt, Unwrap(ex).Message);
            return null;
        }
    }

    private static bool IsPasswordError(Exception ex)
    {
        for (Exception? current = ex; current is not null; current = current.InnerException)
        {
            if (current.Message.Contains("password", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }

    private static Exception Unwrap(Exception ex)
    {
        Exception current = ex;
        while (current.InnerException is not null)
        {
            current = current.InnerException;
        }

        return current;
    }

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        _disposed = true;
        if (OwnsEngine)
        {
            _engine.Dispose();
        }
    }
}
