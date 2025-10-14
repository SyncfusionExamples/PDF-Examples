using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Loads the page.
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

    //Acquires graphics of the page.
    PdfGraphics graphics = loadedPage.Graphics;

    //Set the pen. 
    PdfPen pen = new PdfPen(Color.Red);

    //Set the brush. 
    PdfBrush brush = new PdfSolidBrush(Color.Blue);

    //Set the bounds. 
    RectangleF rectangle = new RectangleF(0, 0, 100, 100);

    //Default color space.
    graphics.DrawRectangle(pen, brush, rectangle);
    graphics.Save();

    //GrayScale color space.
    graphics.ColorSpace = PdfColorSpace.GrayScale;
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
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}