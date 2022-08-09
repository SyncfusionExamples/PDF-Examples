// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream("../../../Input.pdf", FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

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

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
