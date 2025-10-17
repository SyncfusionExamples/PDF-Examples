using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page to the document.
    PdfPage page = document.Pages.Add();

    //Initialize PdfSolidBrush for drawing the rectangle.
    PdfSolidBrush brush = new PdfSolidBrush(Color.Green);

    //Set the bounds for rectangle.
    RectangleF bounds = new RectangleF(10, 10, 100, 50);

    //Draw the rectangle on PDF document.
    page.Graphics.DrawRectangle(brush, bounds);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
