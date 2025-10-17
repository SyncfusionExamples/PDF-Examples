using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page to the document.
    PdfPage page = document.Pages.Add();

    //Initialize the pen for drawing an arc.
    PdfPen pen = new PdfPen(Color.Brown, 10f);

    //Set the line join style of the pen.
    pen.LineCap = PdfLineCap.Square;

    //Set the bounds for arc.
    RectangleF bounds = new RectangleF(20, 40, 200, 200);

    //Draw the arc on PDF document.
    page.Graphics.DrawArc(pen, bounds, 270, 90);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}