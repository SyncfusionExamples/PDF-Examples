using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the page into PdfLoadedPage.
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

    //Initialize PdfPen to draw the polygon.
    PdfPen pen = new PdfPen(PdfBrushes.Brown, 10f);

    //Initialize PdfLinearGradientBrush for drawing the polygon.
    PdfLinearGradientBrush brush = new PdfLinearGradientBrush(new PointF(10, 100), new PointF(100, 200), new PdfColor(Color.Red), new PdfColor(Color.Green));

    //Create the polygon points.
    PointF p1 = new PointF(10, 100);
    PointF p2 = new PointF(10, 200);
    PointF p3 = new PointF(100, 100);
    PointF p4 = new PointF(100, 200);
    PointF p5 = new PointF(55, 150);
    PointF[] points = { p1, p2, p3, p4, p5 };

    //Draw the polygon on PDF document.
    loadedPage.Graphics.DrawPolygon(pen, brush, points);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}