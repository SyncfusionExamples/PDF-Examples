// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Creates a new PDF document.
PdfDocument pdfDocument = new PdfDocument();

//Adds a page to the PDF document.
PdfPage pdfPage = pdfDocument.Pages.Add();

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

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    pdfDocument.Save(outputFileStream);
}

//Close the document.
pdfDocument.Close(true);
