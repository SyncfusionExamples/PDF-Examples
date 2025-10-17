using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page to the document.
    PdfPage page = document.Pages.Add();

    //Create PDF graphics for the page.
    PdfGraphics graphics = page.Graphics;

    //Create new PDF radial gradient brush.
    PdfRadialGradientBrush brush = new PdfRadialGradientBrush(new PointF(50, 50), 0, new PointF(50, 50), 50, Color.Red, Color.Blue);

    //Draw ellipse on the page.
    graphics.DrawEllipse(brush, new RectangleF(0, 0, 100, 100));

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
