using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.ColorSpace;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Adds a page to the PDF document.
    PdfPage pdfPage = document.Pages.Add();

    //Acquires graphics of the page.
    PdfGraphics graphics = pdfPage.Graphics;

    //Creates CalGray color space.
    PdfCalGrayColorSpace calGrayColorSpace = new PdfCalGrayColorSpace();

    //Updates color values.
    calGrayColorSpace.Gamma = 0.7;
    calGrayColorSpace.WhitePoint = new double[] { 0.2, 1, 0.8 };

    //Create another CalGray color space. 
    PdfCalGrayColor calGrayColorSpace1 = new PdfCalGrayColor(calGrayColorSpace);

    //Updates the color value. 
    calGrayColorSpace1.Gray = 0.1;

    //Set the brush. 
    PdfBrush brush = new PdfSolidBrush(calGrayColorSpace1);

    //Set the bounds. 
    RectangleF bounds = new RectangleF(0, 0, 300, 300);

    //Draws rectangle by using the PdfBrush.
    graphics.DrawRectangle(brush, bounds);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
