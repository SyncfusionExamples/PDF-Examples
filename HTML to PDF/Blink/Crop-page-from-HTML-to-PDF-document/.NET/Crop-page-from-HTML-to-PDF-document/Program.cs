using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

// Create an HTML-to-PDF converter instance
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
// Convert the given URL to a PDF document
using (PdfDocument document = htmlConverter.Convert("https://www.google.com"))
using (PdfDocument croppedDocument = new PdfDocument())
{
    // Get the first page from the converted PDF
    PdfPage srcPage = document.Pages[0];
    // Create a template of the entire source page
    PdfTemplate template = srcPage.CreateTemplate();
    // Define the crop height (3.6 inches converted to points)
    float cropHeight = 3.6f * 72f;
    float pageWidth = srcPage.GetClientSize().Width; // Get original page width
    // Configure the new document's page settings for cropping
    croppedDocument.PageSettings.Margins.All = 0;
    croppedDocument.PageSettings.Width = pageWidth;
    croppedDocument.PageSettings.Height = cropHeight;
    // Add a new page to the cropped document
    PdfPage destPage = croppedDocument.Pages.Add();
    // Draw the cropped template onto the new page
    destPage.Graphics.DrawPdfTemplate(template, new PointF(0, 0));
    // Save the cropped PDF document
    croppedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}