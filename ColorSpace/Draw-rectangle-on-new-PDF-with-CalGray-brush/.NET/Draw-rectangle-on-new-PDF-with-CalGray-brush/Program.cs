// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.ColorSpace;
using Syncfusion.Pdf.Graphics;

//Creates a new PDF document.
PdfDocument pdfDocument = new PdfDocument();

//Adds a page to the PDF document.
PdfPage pdfPage = pdfDocument.Pages.Add();

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

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    pdfDocument.Save(outputFileStream);
}

//Close the document.
pdfDocument.Close(true);
