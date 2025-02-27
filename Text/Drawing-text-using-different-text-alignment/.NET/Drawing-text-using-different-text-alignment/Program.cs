
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

//Create a new PDF document
PdfDocument document = new PdfDocument();
//Add a page to the document
PdfPage page = document.Pages.Add();
//Create PDF graphics for the page
PdfGraphics graphics = page.Graphics;
//Create new instance for string format
PdfStringFormat format = new PdfStringFormat();

//Set horizontal text alignment
format.Alignment = PdfTextAlignment.Right;
format.WordSpacing = 2f;
format.CharacterSpacing = 1f;

//Set the standard font
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
//Draw the rectangle
graphics.DrawRectangle(PdfPens.Black, new RectangleF(10, 10, 200, 20));
//Draw the text
graphics.DrawString("Right-Alignment", font, PdfBrushes.Red, new RectangleF(10, 10, 200, 20), format);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}
//Close the document
document.Close(true);