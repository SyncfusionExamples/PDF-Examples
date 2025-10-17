using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the page into PdfLoadedPage.
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

    //Initialize PdfSolidBrush for drawing the ellipse.
    PdfSolidBrush brush = new PdfSolidBrush(Color.Red);

    //Draw ellipse on the page.
    loadedPage.Graphics.DrawEllipse(brush, new RectangleF(10, 10, 200, 100));

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}