using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using System.Reflection.Metadata;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Get the size of the first page
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

    // Insert a new page at the beginning with the same size as the first page
    PdfPageBase page = loadedDocument.Pages.Insert(0, loadedPage.Size);

    // Set the standard font
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
    // Draw the text on the page, centered
    page.Graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));
    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}