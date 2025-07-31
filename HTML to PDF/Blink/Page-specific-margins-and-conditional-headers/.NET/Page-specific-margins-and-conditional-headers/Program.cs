using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

// Initialize HTML to PDF converter
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

// ======= HTML to PDF with No Margin =======
// Set converter settings
BlinkConverterSettings settings = new BlinkConverterSettings();
settings.Margin.All = 0;
htmlConverter.ConverterSettings = settings;

// Load HTML content from a file
string html = File.ReadAllText(Path.GetFullPath(@"Data/Sample.html"));

// Convert HTML to PDF
using (PdfDocument document = htmlConverter.Convert(html, ""))
{
    using (FileStream fileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
    {
        // Save the converted PDF document
        document.Save(fileStream);
    }
}
// ======= HTML to PDF with Top and Bottom Margins =======
// Set different converter settings
BlinkConverterSettings settings1 = new BlinkConverterSettings();
settings1.Margin.Top = 50;
settings1.Margin.Bottom = 50;
settings1.Margin.Left = 0;
settings1.Margin.Right = 0;
htmlConverter.ConverterSettings = settings1;

// Convert HTML to PDF with updated settings
using (PdfDocument document1 = htmlConverter.Convert(html, ""))
{
    using (FileStream fileStream1 = new FileStream(Path.GetFullPath(@"Output/Output1.pdf"), FileMode.Create, FileAccess.ReadWrite))
    {
        // Save the converted PDF document
        document1.Save(fileStream1);
    }
}

// Load the source
using (FileStream inputStream = new FileStream(Path.GetFullPath(@"Output/Output1.pdf"), FileMode.Open, FileAccess.Read))
using (FileStream inputStream1 = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Open, FileAccess.Read))
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputStream))
using (PdfLoadedDocument loadedDocument1 = new PdfLoadedDocument(inputStream1))
using (PdfDocument finalDocument = new PdfDocument())
{
    // Define pages requiring headers
    HashSet<int> pagesWithHeaders = new HashSet<int> { 0, 2 }; // 0-based: pages 1 and 3

    // Create margin and header settings
    float headerHeight = 50;
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
    PdfBrush brush = PdfBrushes.Black;
    string headerText = "Page Header";

    // Iterate over each page in the original document
    for (int i = 0; i < loadedDocument.Pages.Count; i++)
    {
        PdfTemplate contentTemplate;
        PdfPage destPage = finalDocument.Pages.Add();
        destPage.Section.PageSettings.Margins.All = 0;

        if (pagesWithHeaders.Contains(i))
        {
            // Page requires a header, copy from loadedDocument1
            PdfLoadedPage loadedPage = loadedDocument1.Pages[i] as PdfLoadedPage;

            // Create and apply the header
            PdfGraphics graphics = destPage.Graphics;
            graphics.DrawString(headerText, font, brush, new PointF(0, 0));

            // Adjust for non-overlapping content
            contentTemplate = loadedPage.CreateTemplate();
            graphics.DrawPdfTemplate(contentTemplate, new PointF(0, headerHeight));

            // Set top margin
            destPage.Section.PageSettings.Margins.Top = headerHeight;
        }
        else
        {
            // No header needed, copy from loadedDocument
            PdfLoadedPage loadedPage = loadedDocument.Pages[i] as PdfLoadedPage;

            // Directly draw content
            contentTemplate = loadedPage.CreateTemplate();
            destPage.Graphics.DrawPdfTemplate(contentTemplate, new PointF(0, 0));
        }
    }

    using (FileStream fileStream2 = new FileStream(Path.GetFullPath(@"Output/FinalOutput.pdf"), FileMode.Create, FileAccess.ReadWrite))
    {
        // Save the converted PDF document
        finalDocument.Save(fileStream2);
    }
}