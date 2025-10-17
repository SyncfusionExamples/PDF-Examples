using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page to the document.
    PdfPage page = document.Pages.Add();

    //Initialize a new PDF path.
    PdfPath path = new PdfPath();

    //Add line path points.
    path.AddLine(new PointF(10, 100), new PointF(10, 200));
    path.AddLine(new PointF(10, 200), new PointF(100, 100));
    path.AddLine(new PointF(100, 100), new PointF(100, 200));
    path.AddLine(new PointF(100, 200), new PointF(10, 100));

    //Draw the PDF path on page.
    page.Graphics.DrawPath(PdfPens.Black, path);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}