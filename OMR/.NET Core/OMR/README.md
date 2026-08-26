# OMR Sample

Template-based Optical Mark Recognition (OMR) sample package for **.NET 9**. The library reads filled bubbles on a scanned answer sheet (PNG/JPEG or a scanned PDF page), aligns the page to a JSON template, and returns structured results.

## What you get

| Project / Folder | Use it for |
| --- | --- |
| [lib](lib) | Pre-compiled Release assemblies for `Omr.Engine` |
| [src/Omr.Pdf](src/Omr.Pdf) | Run the engine over a multi-page **scanned** PDF |
| [src/Omr.Poc](src/Omr.Poc) | End-to-end console sample: generate a PDF, decode QR, grade, annotate, write CSV |
| [samples/templates/exam-cs101-v3.json](samples/templates/exam-cs101-v3.json) | Example exam template |

The engine does **not** grade papers, send email, or require WinForms. The POC demonstrates those as replaceable callbacks.

## Requirements

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Network access to restore NuGet packages (SkiaSharp, Syncfusion PDF, ZXing for the POC)
- Optional: `SYNCFUSION_LICENSE` — without a key, Syncfusion may watermark generated PDFs

Linux CI/dev images already use `SkiaSharp.NativeAssets.Linux.NoDependencies`.

## Build

```bash
dotnet build Omr.sln
```

## Run the sample (POC)

The console app generates a synthetic multi-page exam PDF, recognizes each page, applies a sample grading formula, and writes outputs to a folder.

```bash
dotnet run --project src/Omr.Poc -- --pages 4 --out ./poc-output
```

| Argument | Default | Meaning |
| --- | --- | --- |
| `--pages` | `3` | Number of answer sheets to generate and process |
| `--out` | `./poc-output` | Output directory |

**Outputs**

| File | Contents |
| --- | --- |
| `exam-batch.pdf` | Generated input batch |
| `page-NNN.json` | Recognition result for that page |
| `page-NNN.png` | Annotated correction image |
| `annotated.pdf` | All annotated pages |
| `summary.csv` | Student id, grade, answers, review flag, paths |

QR payloads in the sample look like `exam-cs101|v3|student-001`. Ctrl+C cancels a run.

Page variants in the sample: all correct, one wrong answer, one blank, one double-mark (needs review).

## Use the engine on an image

Reference `lib/Omr.Engine.dll` from your app.

```csharp
using Omr.Engine;
using Omr.Engine.Templates;

OmrTemplate template = OmrTemplate.Load("exam-cs101-v3.json");
template.EnsureValid();

var options = new OmrRecognitionOptions
{
    FilledThreshold = 0.70f,
    BlankThreshold = 0.20f,
    AutoRotate = true,
    Deskew = true,
    MinAlignmentScore = 0.35f
};

using var processor = new OmrProcessor(options);
Omr.Engine.Results.OmrPageResult result = processor.Recognize("scan.png", template);

Console.WriteLine($"{result.PageStatus} align={result.AlignmentScore:0.00}");

foreach (var group in result.Groups)
{
    Console.WriteLine($"{group.Id}: {group.Status} [{string.Join(",", group.SelectedOptionIds)}]");
}

File.WriteAllText("page.json", result.ToJson());
```

`Recognize` also accepts a `Stream` or a SkiaSharp `SKBitmap`. Pass `sourcePageIndex` when the image came from a PDF page.

### Recognition options

| Option | Default | Role |
| --- | --- | --- |
| `FilledThreshold` | `0.70` | Fill score at or above this counts as filled |
| `BlankThreshold` | `0.20` | Fill score at or below this counts as empty |
| `AutoRotate` | `true` | Try 0° / 90° / 180° / 270° using anchors |
| `Deskew` | `true` | Small-angle deskew |
| `MinAlignmentScore` | `0.35` | Below this, the page fails (no silent answers) |
| `TreatMultipleAsReview` | `true` | `Multiple` groups set page `NeedsReview` |
| `TreatAmbiguousAsReview` | `true` | `Ambiguous` groups set page `NeedsReview` |
| `MinEffectiveDpi` | `150` | Warn/fail when estimated DPI is too low |

Require `0 ≤ BlankThreshold < FilledThreshold ≤ 1`.

### Result statuses

**Page:** `Succeeded`, `NeedsReview`, `Failed`, `Skipped`

**Group:** `Selected`, `Blank`, `Multiple`, `Ambiguous`, `Unreadable`

The engine never picks a winner when two bubbles are filled or a mark is in the ambiguous band. Light/erased marks show as `Partial` or `ErasureSuspect` on the option, and the group becomes `Ambiguous` (not a silent `Selected`).

## Use the PDF adapter

Reference `Omr.Engine` and `Omr.Pdf`. PDFs must be **scanned sheets** (each page contains an embedded raster). Vector-only pages cannot be rasterized in this build.

```csharp
using Omr.Engine;
using Omr.Engine.Templates;
using Omr.Pdf;

OmrTemplate template = OmrTemplate.Load("exam-cs101-v3.json");

using var engine = new OmrProcessor();
using var pdf = new PdfOmrProcessor(engine);

await foreach (var page in pdf.RecognizeAsync(
    "exams.pdf",
    templateResolver: new MyTemplateResolver(template),
    barcodeDecoder: new MyQrDecoder(),   // optional; implement IBarcodeDecoder
    options: new PdfOmrOptions
    {
        RequireQr = true,
        FallbackTemplate = template,
        StartPageIndex = 0,
        FailFast = false
    }))
{
    // Grade and store using page.Groups — not the engine
}
```

| `PdfOmrOptions` | Default | Role |
| --- | --- | --- |
| `RequireQr` | `true` | Fail the page if QR decode returns nothing |
| `FallbackTemplate` | `null` | Template when the resolver returns null |
| `StartPageIndex` / `EndPageIndexInclusive` | all pages | Page range (0-based) |
| `FailFast` | `false` | Stop the batch on the first failed page |

Implement `ITemplateResolver.Resolve(qrValue)` to map a QR string to a template. The sample resolver (`CatalogTemplateResolver`) understands `templateId|version|studentId`.

Implement `IBarcodeDecoder` yourself (the POC uses ZXing). The engine does not depend on a barcode library.

## Define a template

Coordinates are **normalized** `[0, 1]` with origin at the **top-left**, Y down. Use at least **three** `anchor` regions (four corners work well); make one fiducial larger so 180° rotation can be distinguished.

```json
{
  "schemaVersion": "1.0",
  "templateId": "exam-cs101",
  "templateVersion": "3",
  "page": { "width": 8.5, "height": 11.0, "unit": "inch", "orientation": "portrait" },
  "regions": [
    { "id": "tl-anchor", "kind": "anchor", "rect": { "x": 0.035, "y": 0.032, "w": 0.055, "h": 0.042 } },
    { "id": "qr", "kind": "barcode", "rect": { "x": 0.70, "y": 0.035, "w": 0.22, "h": 0.12 } }
  ],
  "groups": [
    {
      "id": "q1",
      "groupKind": "answer",
      "linkedGroupId": "q1-confidence",
      "selectionPolicy": "single",
      "marks": [
        { "id": "A", "shape": "oval", "rect": { "x": 0.16, "y": 0.24, "w": 0.045, "h": 0.028 } }
      ]
    }
  ]
}
```

- `kind`: `anchor` | `barcode` | `mark` (marks usually live under `groups`)
- `selectionPolicy`: `single` or `multiple`
- `groupKind`: `answer` | `confidence` | `other` (hints only; scoring is the same)
- `shape`: `oval` | `circle` | `square` | `rectangle`

Load and check before a batch: `OmrTemplate.Load(path)` then `EnsureValid()` / `Validate()`.

Print registration marks on the physical sheet in the same places as the `anchor` rects.

## Plug in grading and delivery (POC)

The POC keeps grading out of the engine:

- `IExamGrader` / `WeightedConfidenceGrader` — example: correct + High=1.0, Medium=0.5, Low=0.25; blank/multiple/ambiguous score 0 and flag review
- `IResultDelivery` / `FolderDelivery` — writes `summary.csv` (swap this for email or a test mailbox)
- `GradeAnnotator` — draws OK / X / ? on a copy of the page

Copy those types into your app or replace them.

## Scan quality

Use clean 150–300 DPI scans, full page visible, dark filled bubbles, and printed corner anchors. Crops that clip anchors, extreme skew, or faint marks produce `NeedsReview` or `Failed` with a reason instead of a guessed answer.

## Limits

- No handwriting / OCR
- No exam layout generator
- No production email or student directory
- Scanned PDF pages must contain an embedded image; Pdfium page rendering is not included (it crashed on some Linux hosts)
- Console POC only (not a WinForms UI)

## License

This repository is under the [Unlicense](LICENSE). Syncfusion and other NuGet dependencies have their own licenses.
