using Omr.Engine.Geometry;
using Omr.Engine.Templates;
using SkiaSharp;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

namespace Omr.Poc;

public sealed record SheetMarks(
    string StudentId,
    IReadOnlyDictionary<string, string> Answers,
    IReadOnlyDictionary<string, string> Confidence,
    IReadOnlySet<string>? ExtraFilledAnswers = null);

public static class SampleExamFactory
{
    public static string QrPayload(string studentId) => $"exam-cs101|v3|{studentId}";

    public static SKBitmap RenderSheet(OmrTemplate template, SheetMarks marks, int dpi = 150)
    {
        int width = (int)(template.Page.WidthInches * dpi);
        int height = (int)(template.Page.HeightInches * dpi);
        SKBitmap bitmap = new(width, height, SKColorType.Bgra8888, SKAlphaType.Opaque);
        using SKCanvas canvas = new(bitmap);
        canvas.Clear(SKColors.White);

        using SKPaint black = new() { Color = SKColors.Black, IsAntialias = true, Style = SKPaintStyle.Fill };
        using SKPaint stroke = new()
        {
            Color = SKColors.Black,
            IsAntialias = true,
            Style = SKPaintStyle.Stroke,
            StrokeWidth = Math.Max(2, width / 500f)
        };
        using SKFont font = new(SKTypeface.Default, Math.Max(14, width / 55f));
        using SKPaint text = new() { Color = SKColors.Black, IsAntialias = true };

        canvas.DrawText("CS101 answer sheet", Px(template, 0.16f, true, width), Px(template, 0.12f, false, height), font, text);

        foreach (OmrRegion region in template.Regions)
        {
            SKRect rect = ToRect(region.Rect, width, height);
            switch (region.Kind)
            {
                case Omr.Engine.RegionKind.Anchor:
                    canvas.DrawRect(rect, black);
                    break;
                case Omr.Engine.RegionKind.Barcode:
                    using (SKBitmap qr = ZXingBarcodeDecoder.EncodeQr(QrPayload(marks.StudentId), (int)rect.Width, (int)rect.Height))
                    {
                        canvas.DrawBitmap(qr, rect);
                    }

                    break;
                case Omr.Engine.RegionKind.Mark:
                    break;
                default:
                    throw new InvalidOperationException($"Unhandled region kind {region.Kind}.");
            }
        }

        foreach (OmrGroup group in template.Groups)
        {
            foreach (OmrMark mark in group.Marks)
            {
                SKRect rect = ToRect(mark.Rect, width, height);
                canvas.DrawOval(rect, stroke);
                bool fill = IsFilled(group, mark, marks);
                if (fill)
                {
                    rect.Inflate(-rect.Width * 0.18f, -rect.Height * 0.18f);
                    canvas.DrawOval(rect, black);
                }
            }
        }

        return bitmap;
    }

    public static void WritePdf(string path, OmrTemplate template, IReadOnlyList<SheetMarks> sheets, int dpi = 150)
    {
        using PdfDocument document = new();
        document.PageSettings.Margins.All = 0;
        document.PageSettings.Size = PdfPageSize.Letter;
        document.PageSettings.Orientation = PdfPageOrientation.Portrait;

        foreach (SheetMarks sheet in sheets)
        {
            using SKBitmap raster = RenderSheet(template, sheet, dpi);
            using MemoryStream png = new();
            raster.Encode(png, SKEncodedImageFormat.Png, 90);
            png.Position = 0;

            PdfPage page = document.Pages.Add();
            using PdfBitmap image = new(png);
            var size = page.GetClientSize();
            page.Graphics.DrawImage(image, 0, 0, size.Width, size.Height);
        }

        using FileStream output = File.Create(path);
        document.Save(output);
    }

    private static bool IsFilled(OmrGroup group, OmrMark mark, SheetMarks marks)
    {
        if (group.GroupKind == Omr.Engine.GroupKind.Answer)
        {
            if (marks.Answers.TryGetValue(group.Id, out string? selected) && selected == mark.Id)
            {
                return true;
            }

            return marks.ExtraFilledAnswers is not null && marks.ExtraFilledAnswers.Contains($"{group.Id}:{mark.Id}");
        }

        if (group.GroupKind == Omr.Engine.GroupKind.Confidence)
        {
            string questionId = group.Id.Replace("-confidence", "", StringComparison.Ordinal);
            return marks.Confidence.TryGetValue(questionId, out string? level) && level == mark.Id;
        }

        return false;
    }

    private static SKRect ToRect(NormalizedRect rect, int width, int height)
    {
        return new SKRect(
            rect.X * width,
            rect.Y * height,
            rect.Right * width,
            rect.Bottom * height);
    }

    private static float Px(OmrTemplate template, float n, bool horizontal, int size)
    {
        _ = template;
        return horizontal ? n * size : n * size;
    }
}
