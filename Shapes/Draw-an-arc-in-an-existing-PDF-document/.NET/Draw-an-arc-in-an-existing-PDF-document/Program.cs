using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the page into PdfLoadedPage.
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

    //Initialize the pen for drawing an arc.
    PdfPen pen = new PdfPen(Color.Brown, 10f);

    //Set the line join style of the pen.
    pen.LineCap = PdfLineCap.Square;

    //Set the bounds for arc.
    RectangleF bounds = new RectangleF(20, 40, 200, 200);

    //Draw the arc on PDF document.
    loadedPage.Graphics.DrawArc(pen, bounds, 270, 90);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}