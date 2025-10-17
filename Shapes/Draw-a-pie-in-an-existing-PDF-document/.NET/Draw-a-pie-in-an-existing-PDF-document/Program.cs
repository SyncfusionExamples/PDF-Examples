using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the page into PdfLoadedPage.
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

    //Initialize the pen for drawing pie.
    PdfPen pen = new PdfPen(PdfBrushes.Brown, 5f);

    //Set the line join style of the pen.
    pen.LineJoin = PdfLineJoin.Round;

    //Set the bounds for pie.
    RectangleF rectangle = new RectangleF(10, 50, 200, 200);

    //Draw the pie on PDF document
    loadedPage.Graphics.DrawPie(pen, PdfBrushes.Green, rectangle, 180, 60);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}