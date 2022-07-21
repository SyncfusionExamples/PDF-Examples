// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a page to the document.
PdfPage page = document.Pages.Add();

//Create PDF graphics for the page.
PdfGraphics graphics = page.Graphics;

//Create new PDF radial gradient brush.
PdfRadialGradientBrush brush = new PdfRadialGradientBrush(new PointF(50, 50), 0, new PointF(50, 50), 50, Color.Red, Color.Blue);

//Draw ellipse on the page.
graphics.DrawEllipse(brush, new RectangleF(0, 0, 100, 100));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
