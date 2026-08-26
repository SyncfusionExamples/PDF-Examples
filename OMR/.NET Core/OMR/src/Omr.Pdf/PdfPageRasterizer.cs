using Omr.Engine;
using SkiaSharp;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Exporting;
using Syncfusion.Pdf.Parsing;

namespace Omr.Pdf;

internal static class PdfPageRasterizer
{
    public static SKBitmap Rasterize(PdfLoadedDocument document, int pageIndex, PdfOmrOptions options)
    {
        _ = options;
        SKBitmap? extracted = TryExtractLargestEmbeddedImage(document, pageIndex);
        if (extracted is not null)
        {
            return extracted;
        }

        throw new OmrException(
            WorkflowFailureReasons.PageRenderFailed,
            "The page has no extractable scan image. Vector-only PDF rasterization via Pdfium is not used in this build.");
    }

    private static SKBitmap? TryExtractLargestEmbeddedImage(PdfLoadedDocument document, int pageIndex)
    {
        if (document.Pages[pageIndex] is not PdfLoadedPage page)
        {
            return null;
        }

        Stream[]? images = PdfImageExtractor.ExtractImages(page);
        if (images is null || images.Length == 0)
        {
            return null;
        }

        SKBitmap? best = null;
        int bestPixels = -1;
        foreach (Stream imageStream in images)
        {
            using (imageStream)
            {
                if (imageStream.CanSeek)
                {
                    imageStream.Position = 0;
                }

                SKBitmap? candidate = SKBitmap.Decode(imageStream);
                if (candidate is null)
                {
                    continue;
                }

                int pixels = candidate.Width * candidate.Height;
                if (pixels > bestPixels)
                {
                    best?.Dispose();
                    best = candidate;
                    bestPixels = pixels;
                }
                else
                {
                    candidate.Dispose();
                }
            }
        }

        return best;
    }
}
