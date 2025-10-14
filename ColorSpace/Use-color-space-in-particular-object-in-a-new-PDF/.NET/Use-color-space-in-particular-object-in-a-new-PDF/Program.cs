using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Adds a page to the PDF document.
    PdfPage pdfPage = document.Pages.Add();

    //Acquires graphics of the page.
    PdfGraphics graphics = pdfPage.Graphics;

    //Set pen. 
    PdfPen pen = new PdfPen(Color.Red);

    //Set brush. 
    PdfBrush brush = new PdfSolidBrush(Color.Blue);

    //Set bounds. 
    RectangleF rectangle = new RectangleF(0, 0, 100, 100);

    //Default color space.
    graphics.DrawRectangle(pen, brush, rectangle);
    graphics.Save();

    //GrayScale color space.
    graphics.ColorSpace = PdfColorSpace.GrayScale;

    //Draw rectangle in page graphics. 
    graphics.DrawRectangle(pen, brush, rectangle);

    //CMYK color space.
    graphics.ColorSpace = PdfColorSpace.CMYK;

    //Draw rectangle. 
    graphics.DrawRectangle(pen, brush, rectangle);

    graphics.Restore();

    //Default color space.
    graphics.DrawRectangle(pen, brush, rectangle);

    //Draws by using the PdfBrush.
    graphics.DrawRectangle(brush, rectangle);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

