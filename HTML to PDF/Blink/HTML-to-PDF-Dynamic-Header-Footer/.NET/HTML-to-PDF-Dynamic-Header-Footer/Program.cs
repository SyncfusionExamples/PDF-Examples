using Syncfusion.Pdf;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Parsing;


//Initialize HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();
blinkConverterSettings.Margin.Top = 50;
blinkConverterSettings.Margin.Bottom = 50;
//Assign Blink converter settings to HTML converter.
htmlConverter.ConverterSettings = blinkConverterSettings;
//Convert URL to PDF document.
PdfDocument pdfDocument = htmlConverter.Convert("https://www.syncfusion.com");
MemoryStream stream = new MemoryStream();
pdfDocument.Save(stream);
pdfDocument.Close(true);
htmlConverter.Close();

PdfDocument document = new PdfDocument();
PdfLoadedDocument pdfLoaded = new PdfLoadedDocument(stream);
for (int i = 0; i < pdfLoaded.Pages.Count; i++)
{
    // Import each page from the source document into the target document.
    document.ImportPage(pdfLoaded, i);
}


//Create and set the header and footer for even and odd pages.
document.Template.OddTop = createPageHeader(isOdd: true);
document.Template.OddBottom = createPageFooter(isOdd: true);
document.Template.EvenTop = createPageHeader(isOdd: false);
document.Template.EvenBottom = createPageFooter(isOdd: false);


//Save and close the PDF document.
document.Save("HTML-to-PDF.pdf");
document.Close(true);

// Method to create page header based on page type (odd/even)
static PdfPageTemplateElement createPageHeader(bool isOdd)
{
    PdfPageTemplateElement headerTemplate = new PdfPageTemplateElement(PdfPageSize.A4.Width, 50);
    PdfFont titleFont = new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Bold);
    PdfFont regularFont = new PdfStandardFont(PdfFontFamily.Helvetica, 9);

    // Set colors and text based on page type
    Color textColor = isOdd ? Color.Black : Color.FromArgb(64, 64, 64);
    PdfBrush brush = new PdfSolidBrush(textColor);
    PdfPen pen = new PdfPen(textColor, 1);

    // Draw top border line
    headerTemplate.Graphics.DrawLine(pen, new PointF(10, 45), new PointF(PdfPageSize.A4.Width - 10, 45));

    // Draw title with odd/even indication
    string pageType = isOdd ? "[ODD PAGE]" : "[EVEN PAGE]";
    string headerText = isOdd
        ? $"{pageType} - Syncfusion HTML to PDF Conversion"
        : $"{pageType} - Dynamic Header and Footer Demo";
    headerTemplate.Graphics.DrawString(headerText, titleFont, brush, new PointF(10, 5));

    // Draw date/time on the right
    string infoText = isOdd
        ? "Date: " + DateTime.Now.ToString("MMM dd, yyyy")
        : "Time: " + DateTime.Now.ToString("hh:mm tt");
    SizeF size = regularFont.MeasureString(infoText);
    headerTemplate.Graphics.DrawString(infoText, regularFont, brush, new PointF(PdfPageSize.A4.Width - size.Width - 10, 20));

    return headerTemplate;
}

// Method to create page footer based on page type (odd/even)
static PdfPageTemplateElement createPageFooter(bool isOdd)
{
    PdfPageTemplateElement footerTemplate = new PdfPageTemplateElement(PdfPageSize.A4.Width, 50);
    PdfFont regularFont = new PdfStandardFont(PdfFontFamily.Helvetica, 9);
    PdfFont pageNumberFont = new PdfStandardFont(PdfFontFamily.Helvetica, 10, PdfFontStyle.Bold);

    // Set colors based on page type
    Color textColor = isOdd ? Color.Black : Color.FromArgb(64, 64, 64);
    PdfBrush brush = new PdfSolidBrush(textColor);
    PdfPen pen = new PdfPen(textColor, 1);

    // Draw bottom border line
    footerTemplate.Graphics.DrawLine(pen, new PointF(10, 5), new PointF(PdfPageSize.A4.Width - 10, 5));

    // Draw company info on the left with odd/even indicator
    string pageType = isOdd ? "ODD" : "EVEN";
    string copyRight = $"© {DateTime.Now.Year} Syncfusion, Inc. All rights reserved. [{pageType} FOOTER]";
    footerTemplate.Graphics.DrawString(copyRight, regularFont, brush, new PointF(10, 15));

    // Draw page number on the right with field placeholder
    // Note: Use a placeholder that can be replaced with actual page numbers
    // PageNumber field will be added as a template field
    PdfPageNumberField pageNumberField = new PdfPageNumberField(pageNumberFont, brush);
    pageNumberField.Draw(footerTemplate.Graphics, new PointF(PdfPageSize.A4.Width - 50, 15));

    return footerTemplate;
}