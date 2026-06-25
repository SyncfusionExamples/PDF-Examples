using Syncfusion.Pdf;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Parsing;


//Initialize HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();
//Set Blink viewport size.
blinkConverterSettings.ViewPortSize = new Syncfusion.Drawing.Size(1280, 0);
blinkConverterSettings.Margin.Top = 50;
blinkConverterSettings.Margin.Bottom = 50;
//Assign Blink converter settings to HTML converter.
htmlConverter.ConverterSettings = blinkConverterSettings;
//Convert URL to PDF document.
PdfDocument pdfDocument = htmlConverter.Convert("https://www.syncfusion.com");
MemoryStream stream = new MemoryStream();
pdfDocument.Save(stream);

PdfDocument document = new PdfDocument();
document.PageSettings.Margins = new PdfMargins
{
    Top = 300,    // Space for the header
    Bottom = 300, // Space for the footer
    Left = 10,
    Right = 10
};
PdfLoadedDocument pdfLoaded = new PdfLoadedDocument(stream);
for (int i = 0; i < pdfDocument.Pages.Count; i++)
{
    // Import each page from the source document into the target document.
    document.ImportPage(pdfLoaded, i);
}
document.Pages.Add();
document.Pages.Add();

for (int i = 0; i < document.Pages.Count; i++)
{
    PdfPage page = document.Pages[i];

    if (i % 2 == 0) // Even pages (0-based index, so 0 is the first page)
    {
        PdfTemplate oddHeader = createOddPageHeader();
        PdfTemplate oddFooter = createOddPageFooter();
        // Add even page header and footer
        page.Graphics.DrawPdfTemplate(oddHeader, new PointF(0, 0));
        page.Graphics.DrawPdfTemplate(oddFooter, new PointF(0, page.Size.Height - 50));
    }
    else // Odd pages
    {
        PdfTemplate evenHeader = createEvenPageHeader();
        PdfTemplate evenFooter = createEvenPageFooter();
        // Add odd page header and footer
        page.Graphics.DrawPdfTemplate(evenHeader, new PointF(0, 0));
        page.Graphics.DrawPdfTemplate(evenFooter, new PointF(0, page.Size.Height - 50));
    }
}

//Save and close the PDF document.
document.Save("../../../HTML-to-PDF.pdf");
document.Close(true);

// Method to create odd-page header
static PdfTemplate createOddPageHeader()
{
    PdfTemplate headerTemplate = new PdfTemplate(PdfPageSize.A4.Width, 50);
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 10);
    PdfBrush brush = new PdfSolidBrush(Color.Black);
    headerTemplate.Graphics.DrawString("Odd Page Header", font, brush, new PointF(10, 10));
    return headerTemplate;
}

// Method to create even-page header
static PdfTemplate createEvenPageHeader()
{
    PdfTemplate headerTemplate = new PdfTemplate(PdfPageSize.A4.Width, 50);
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 10);
    PdfBrush brush = new PdfSolidBrush(Color.Gray);
    headerTemplate.Graphics.DrawString("Even Page Header", font, brush, new PointF(10, 10));
    return headerTemplate;
}

// Method to create odd-page footer
static PdfTemplate createOddPageFooter()
{
    PdfTemplate footerTemplate = new PdfTemplate(PdfPageSize.A4.Width, 50);
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 10);
    PdfBrush brush = new PdfSolidBrush(Color.Black);
    footerTemplate.Graphics.DrawString("Odd Page Footer", font, brush, new PointF(10, 10));
    return footerTemplate;
}

// Method to create even-page footer
static PdfTemplate createEvenPageFooter()
{
    PdfTemplate footerTemplate = new PdfTemplate(PdfPageSize.A4.Width, 50);
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 10);
    PdfBrush brush = new PdfSolidBrush(Color.Gray);
    footerTemplate.Graphics.DrawString("Even Page Footer", font, brush, new PointF(10, 10));
    return footerTemplate;
}