using Omr.Engine;
using Omr.Engine.Geometry;
using Omr.Engine.Processing;
using Omr.Engine.Results;
using Omr.Engine.Templates;
using SkiaSharp;

namespace Omr.Poc;

public static class GradeAnnotator
{
    public static SKBitmap Annotate(SKBitmap source, OmrTemplate template, OmrPageResult page, GradeResult grade)
    {
        AffineTransform transform = AffineTransform.Identity(source.Width, source.Height);
        SKBitmap overlay = OmrDiagnosticsOverlay.Render(source, template, page, transform);
        using SKCanvas canvas = new(overlay);
        using SKFont font = new(SKTypeface.Default, Math.Max(16, overlay.Width / 55f));
        using SKPaint text = new() { IsAntialias = true };

        IReadOnlyDictionary<string, string> key = new Dictionary<string, string>
        {
            ["q1"] = "B",
            ["q2"] = "A",
            ["q3"] = "D",
            ["q4"] = "C",
            ["q5"] = "B"
        };

        foreach (OmrGroupResult group in page.Groups.Where(g => g.GroupKind == GroupKind.Answer))
        {
            key.TryGetValue(group.Id, out string? correct);
            PixelRect band = Band(group);
            SKColor color = group.Status switch
            {
                GroupStatus.Selected when correct is not null && group.SelectedOptionIds.Contains(correct)
                    => new SKColor(0, 150, 60),
                GroupStatus.Selected => new SKColor(200, 30, 30),
                GroupStatus.Blank => new SKColor(180, 120, 0),
                GroupStatus.Multiple => new SKColor(200, 80, 0),
                GroupStatus.Ambiguous => new SKColor(200, 80, 0),
                GroupStatus.Unreadable => new SKColor(90, 90, 90),
                _ => throw new InvalidOperationException($"Unhandled group status {group.Status}.")
            };

            using SKPaint fill = new() { Color = color.WithAlpha(40), Style = SKPaintStyle.Fill };
            using SKPaint stroke = new() { Color = color, Style = SKPaintStyle.Stroke, StrokeWidth = 3, IsAntialias = true };
            canvas.DrawRect(band.X, band.Y, band.Width, band.Height, fill);
            canvas.DrawRect(band.X, band.Y, band.Width, band.Height, stroke);

            string mark = group.Status switch
            {
                GroupStatus.Selected when correct is not null && group.SelectedOptionIds.Contains(correct) => "OK",
                GroupStatus.Selected => "X",
                GroupStatus.Blank => "—",
                GroupStatus.Multiple => "M",
                GroupStatus.Ambiguous => "?",
                GroupStatus.Unreadable => "!",
                _ => throw new InvalidOperationException($"Unhandled group status {group.Status}.")
            };

            text.Color = color;
            canvas.DrawText($"{group.Id} {mark}", band.X + band.Width + 8, band.Y + (band.Height / 2f) + (font.Size / 3f), font, text);
        }

        text.Color = grade.NeedsReview ? new SKColor(180, 80, 0) : new SKColor(0, 90, 40);
        canvas.DrawText($"Grade {grade.Score:0.##}  review={grade.NeedsReview}", 20, overlay.Height - 24, font, text);
        return overlay;
    }

    private static PixelRect Band(OmrGroupResult group)
    {
        if (group.Options.Count == 0)
        {
            return new PixelRect(0, 0, 1, 1);
        }

        int x0 = group.Options.Min(o => o.PixelRect.X);
        int y0 = group.Options.Min(o => o.PixelRect.Y);
        int x1 = group.Options.Max(o => o.PixelRect.X + o.PixelRect.Width);
        int y1 = group.Options.Max(o => o.PixelRect.Y + o.PixelRect.Height);
        return new PixelRect(x0 - 4, y0 - 4, x1 - x0 + 8, y1 - y0 + 8);
    }
}
