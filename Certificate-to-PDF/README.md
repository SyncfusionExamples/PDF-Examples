# Certificate to PDF (ASP.NET Core)

This sample demonstrates how to create a participation certificate and download it as a PDF document using the [Syncfusion PDF Library](https://www.syncfusion.com/document-sdk/net-pdf-library) in an ASP.NET Core (net8.0) MVC application.

## What the sample does

- Shows a form where the user enters the participant name, competition title, date, exam mode and description.
- On submission, the app creates a landscape A4 PDF document with `PdfDocument`.
- Draws the decorated certificate artwork (`wwwroot/Data/CertificateTemplate.jpeg`) as a full-page background image using `PdfGraphics.DrawImage`.
- Draws the certificate text (heading, competition title, certification text, description, organizer, date and signatory blocks) with `PdfTrueTypeFont` fonts shipped in `wwwroot/Fonts`.
- Saves the document to a `MemoryStream` and returns it with `File(...)` so the browser downloads the generated PDF.

## Running the sample

Open the folder in Visual Studio (or use the `dotnet` CLI) and run the project, then fill in the form and click **Create Certificate** to download the PDF.

## Files of interest

- `Controllers/HomeController.cs` — the `CreateCertificate` action that builds the PDF with Syncfusion PDF Library.
- `Models/CertificateModel.cs` — the form model.
- `Views/Home/Index.cshtml` — the certificate details form.
- `wwwroot/Data/CertificateTemplate.jpeg` — the certificate background artwork.

## License

Syncfusion PDF Library requires a license for commercial use. A free 30-day trial is available from Syncfusion.
