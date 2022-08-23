// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.ColorSpace;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Loads the page.
PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

//Acquires graphics of the page.
PdfGraphics graphics = loadedPage.Graphics;

//Creates CalGray color space.
PdfCalGrayColorSpace calGrayColorSpace = new PdfCalGrayColorSpace();

//Updates color values.
calGrayColorSpace.Gamma = 0.7;
calGrayColorSpace.WhitePoint = new double[] { 0.2, 1, 0.8 };

//Creates CalGray color space. 
PdfCalGrayColor calGrayColorSpace1 = new PdfCalGrayColor(calGrayColorSpace);
calGrayColorSpace1.Gray = 0.1;

//Set the brush.  
PdfBrush brush = new PdfSolidBrush(calGrayColorSpace1);

//Set the bounds.
RectangleF bounds = new RectangleF(50, 50, 300, 300);

//Draws rectangle by using the PdfBrush.
graphics.DrawRectangle(brush, bounds);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
