using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page to the document.
    PdfPage page = document.Pages.Add();

    //Initialize PdfSolidBrush for drawing the ellipse.
    PdfSolidBrush brush = new PdfSolidBrush(Color.Red);

    //Draw ellipse on the page.
    page.Graphics.DrawEllipse(brush, new RectangleF(10, 10, 200, 100));

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
