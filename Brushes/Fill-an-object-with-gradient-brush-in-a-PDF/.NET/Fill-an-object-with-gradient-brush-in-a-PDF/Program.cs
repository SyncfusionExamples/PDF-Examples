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

    //Create new PDF linear gradient brush.
    PdfLinearGradientBrush brush = new PdfLinearGradientBrush(new PointF(0, 0), new PointF(200, 100), Color.Red, Color.Blue);

    //Draw ellipse on the page.
    graphics.DrawEllipse(brush, new RectangleF(0, 0, 200, 100));

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
