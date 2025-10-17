using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page to the document.
    PdfPage page = document.Pages.Add();

    //Initialize pen to draw the line.
    PdfPen pen = new PdfPen(PdfBrushes.Black, 5f);

    //Create the line points.
    PointF point1 = new PointF(10, 10);
    PointF point2 = new PointF(10, 100);

    //Draw the line on PDF document.
    page.Graphics.DrawLine(pen, point1, point2);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}