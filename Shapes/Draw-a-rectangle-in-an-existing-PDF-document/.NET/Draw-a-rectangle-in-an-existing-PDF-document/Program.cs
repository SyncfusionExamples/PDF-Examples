using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the page into PdfLoadedPage.
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

    //Initialize PdfSolidBrush for drawing the rectangle.
    PdfSolidBrush brush = new PdfSolidBrush(Color.Green);

    //Set the bounds for rectangle.
    RectangleF bounds = new RectangleF(10, 10, 100, 50);

    //Draw the rectangle on PDF document.
    loadedPage.Graphics.DrawRectangle(brush, bounds);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}