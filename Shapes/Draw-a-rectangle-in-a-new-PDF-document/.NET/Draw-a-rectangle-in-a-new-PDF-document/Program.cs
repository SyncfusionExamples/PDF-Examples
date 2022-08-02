// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a page to the document.
PdfPage page = document.Pages.Add();

//Initialize PdfSolidBrush for drawing the rectangle.
PdfSolidBrush brush = new PdfSolidBrush(Color.Green);

//Set the bounds for rectangle.
RectangleF bounds = new RectangleF(10, 10, 100, 50);

//Draw the rectangle on PDF document.
page.Graphics.DrawRectangle(brush, bounds);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
