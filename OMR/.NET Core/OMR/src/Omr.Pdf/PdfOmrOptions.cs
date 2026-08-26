using Omr.Engine.Templates;

namespace Omr.Pdf;

public sealed class PdfOmrOptions
{
    public float Dpi { get; init; } = 200f;

    public int? StartPageIndex { get; init; }

    public int? EndPageIndexInclusive { get; init; }

    public bool FailFast { get; init; }

    public bool RequireQr { get; init; } = true;

    public bool SkipAnnotations { get; init; }

    /// <summary>
    /// Reserved. Pdfium page rasterization is not loaded in this build (it can crash some Linux hosts).
    /// Scanned sheets are rasterized by extracting the largest embedded page image.
    /// </summary>
    public bool UsePdfiumRasterizer { get; init; }

    public OmrTemplate? FallbackTemplate { get; init; }
}
