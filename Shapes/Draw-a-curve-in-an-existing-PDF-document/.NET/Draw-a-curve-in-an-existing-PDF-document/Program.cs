using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the page into PdfLoadedPage.
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

    //Get the graphics of PdfLoadedPage.
    PdfGraphics graphics = loadedPage.Graphics;

    //Create new instance of PdfBezierCurve.
    PdfBezierCurve bezier = new PdfBezierCurve(new PointF(0, 0), new PointF(100, 50), new PointF(50, 50), new PointF(100, 100));

    //Draw the bezier curve on PDF document.
    bezier.Draw(graphics, new PointF(10, 10));

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}