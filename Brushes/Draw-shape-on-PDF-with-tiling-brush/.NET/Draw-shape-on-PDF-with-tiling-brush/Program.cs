// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a page to the document.
PdfPage page = document.Pages.Add();

//Create PDF graphics for the page.
PdfGraphics graphics = page.Graphics;

//Create new PDF tiling brush.
PdfTilingBrush brush = new PdfTilingBrush(new RectangleF(0, 0, 11, 11));

//Draw ellipse inside the tile.
brush.Graphics.DrawEllipse(PdfPens.Red, new RectangleF(0, 0, 10, 10));

//Draw ellipse.
graphics.DrawEllipse(brush, new RectangleF(0, 0, 200, 100));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
