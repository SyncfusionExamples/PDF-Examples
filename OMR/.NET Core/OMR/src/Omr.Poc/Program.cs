using Omr.Engine;
using Omr.Engine.Results;
using Omr.Engine.Templates;
using Omr.Pdf;
using Omr.Poc;
using SkiaSharp;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Licensing;

string? license = Environment.GetEnvironmentVariable("SYNCFUSION_LICENSE");
if (!string.IsNullOrWhiteSpace(license))
{
    SyncfusionLicenseProvider.RegisterLicense(license);
}

string root = FindRepoRoot();
string templatePath = Path.Combine(root, "samples", "templates", "exam-cs101-v3.json");
if (!File.Exists(templatePath))
{
    templatePath = Path.Combine(AppContext.BaseDirectory, "templates", "exam-cs101-v3.json");
}

OmrTemplate template = OmrTemplate.Load(templatePath);
template.EnsureValid();

int pageCount = GetIntArg("--pages", 3);
string outputDir = GetArg("--out") ?? Path.Combine(root, "poc-output");
Directory.CreateDirectory(outputDir);
string pdfPath = Path.Combine(outputDir, "exam-batch.pdf");

List<SheetMarks> sheets = BuildSheets(pageCount);
SampleExamFactory.WritePdf(pdfPath, template, sheets, dpi: 150);
Console.WriteLine($"Wrote {pdfPath} ({pageCount} pages).");

CatalogTemplateResolver resolver = new(template);
ZXingBarcodeDecoder decoder = new();
OmrRecognitionOptions engineOptions = new()
{
    AutoRotate = false,
    Deskew = false,
    FilledThreshold = 0.55f,
    BlankThreshold = 0.18f,
    MinAlignmentScore = 0.30f,
    MinEffectiveDpi = 100f
};

using OmrProcessor engine = new(engineOptions);
using PdfOmrProcessor pdfProcessor = new(engine);
IExamGrader grader = WeightedConfidenceGrader.Cs101V3();
FolderDelivery delivery = new(outputDir);
List<PageDelivery> delivered = [];
int completed = 0;

using CancellationTokenSource cts = new();
Console.CancelKeyPress += (_, e) =>
{
    e.Cancel = true;
    cts.Cancel();
};

Progress<OmrProgress> progress = new(p =>
{
    Console.WriteLine($"page {p.PageIndex} {p.Status} ({p.PagesCompleted}/{pageCount})");
});

using PdfDocument annotatedPdf = new();
annotatedPdf.PageSettings.Margins.All = 0;
annotatedPdf.PageSettings.Size = PdfPageSize.Letter;

await foreach (OmrPageResult page in pdfProcessor.RecognizeAsync(
    pdfPath,
    resolver,
    decoder,
    new PdfOmrOptions { Dpi = 150, RequireQr = true, FallbackTemplate = template },
    progress,
    cts.Token))
{
    completed++;
    GradeResult grade = grader.Grade(page);
    string jsonPath = Path.Combine(outputDir, $"page-{page.SourcePageIndex:000}.json");
    await File.WriteAllTextAsync(jsonPath, page.ToJson(), cts.Token);

    string imagePath = Path.Combine(outputDir, $"page-{page.SourcePageIndex:000}.png");
    using (SKBitmap source = SampleExamFactory.RenderSheet(template, sheets[page.SourcePageIndex], 150))
    using (SKBitmap annotated = GradeAnnotator.Annotate(source, template, page, grade))
    using (SKFileWStream stream = new(imagePath))
    {
        annotated.Encode(stream, SKEncodedImageFormat.Png, 90);
        using MemoryStream png = new();
        annotated.Encode(png, SKEncodedImageFormat.Png, 90);
        png.Position = 0;
        var pdfPage = annotatedPdf.Pages.Add();
        using PdfBitmap pdfImage = new(png);
        var size = pdfPage.GetClientSize();
        pdfPage.Graphics.DrawImage(pdfImage, 0, 0, size.Width, size.Height);
    }

    string answers = string.Join(';', page.Groups.Where(g => g.GroupKind == GroupKind.Answer)
        .Select(g => $"{g.Id}={string.Join('|', g.SelectedOptionIds)}:{g.Status}"));
    string confidence = string.Join(';', page.Groups.Where(g => g.GroupKind == GroupKind.Confidence)
        .Select(g => $"{g.Id}={string.Join('|', g.SelectedOptionIds)}:{g.Status}"));

    PageDelivery row = new()
    {
        PageIndex = page.SourcePageIndex,
        StudentId = grade.StudentId,
        ExamId = grade.ExamId,
        Grade = grade.Score,
        NeedsReview = grade.NeedsReview,
        PageStatus = page.PageStatus.ToString(),
        FailureReason = page.FailureReason,
        Answers = answers,
        Confidence = confidence,
        Diagnostics = string.Join('|', page.Warnings) + (grade.Notes.Count == 0 ? "" : ";" + string.Join('|', grade.Notes)),
        JsonPath = jsonPath,
        ImagePath = imagePath
    };
    delivered.Add(row);
    await delivery.DeliverAsync(row, cts.Token);
}

string annotatedPath = Path.Combine(outputDir, "annotated.pdf");
await using (FileStream annotatedStream = File.Create(annotatedPath))
{
    annotatedPdf.Save(annotatedStream);
}

await delivery.CompleteAsync(delivered, cts.Token);
OmrBatchSummary summary = OmrBatchSummary.From(delivered.Select((_, i) => new OmrPageResult { PageStatus = Enum.Parse<PageStatus>(delivered[i].PageStatus) }));
Console.WriteLine($"Done. succeeded={summary.Succeeded} review={summary.NeedsReview} failed={summary.Failed} skipped={summary.Skipped}");
Console.WriteLine($"CSV: {Path.Combine(outputDir, "summary.csv")}");
Console.WriteLine($"Annotated PDF: {annotatedPath}");

static List<SheetMarks> BuildSheets(int count)
{
    List<SheetMarks> sheets = [];
    for (int i = 0; i < count; i++)
    {
        int variant = i % 4;
        Dictionary<string, string> answers = new()
        {
            ["q1"] = "B",
            ["q2"] = "A",
            ["q3"] = "D",
            ["q4"] = "C",
            ["q5"] = "B"
        };
        Dictionary<string, string> confidence = new()
        {
            ["q1"] = "H",
            ["q2"] = "H",
            ["q3"] = "M",
            ["q4"] = "H",
            ["q5"] = "L"
        };
        HashSet<string>? extra = null;
        switch (variant)
        {
            case 0:
                break;
            case 1:
                answers["q2"] = "C";
                break;
            case 2:
                answers.Remove("q5");
                confidence.Remove("q5");
                break;
            case 3:
                extra = ["q1:A"];
                break;
            default:
                throw new InvalidOperationException($"Unhandled variant {variant}.");
        }

        sheets.Add(new SheetMarks($"student-{i + 1:000}", answers, confidence, extra));
    }

    return sheets;
}

static string FindRepoRoot()
{
    string dir = AppContext.BaseDirectory;
    while (!string.IsNullOrEmpty(dir))
    {
        if (File.Exists(Path.Combine(dir, "Omr.sln")))
        {
            return dir;
        }

        dir = Directory.GetParent(dir)?.FullName ?? "";
    }

    return Directory.GetCurrentDirectory();
}

static string? GetArg(string name)
{
    string[] args = Environment.GetCommandLineArgs();
    int i = Array.IndexOf(args, name);
    return i >= 0 && i + 1 < args.Length ? args[i + 1] : null;
}

static int GetIntArg(string name, int fallback)
{
    string? raw = GetArg(name);
    return int.TryParse(raw, out int value) ? value : fallback;
}
