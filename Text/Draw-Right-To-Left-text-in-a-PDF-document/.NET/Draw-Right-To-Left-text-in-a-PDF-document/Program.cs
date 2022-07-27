// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Text;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a page to the document.
PdfPage page = document.Pages.Add();

//Create PDF graphics for the page.
PdfGraphics graphics = page.Graphics;

//Create font.
FileStream fontStream = new FileStream(Path.GetFullPath("../../../Arial.ttf"), FileMode.Open, FileAccess.Read);
PdfFont font = new PdfTrueTypeFont(fontStream, 14);

//Set the format for string.
PdfStringFormat format = new PdfStringFormat();

//Set right-to-left text direction for RTL text.
format.TextDirection = PdfTextDirection.RightToLeft;

//Set the alignment.
format.Alignment = PdfTextAlignment.Right;
format.ParagraphIndent = 35f;

//Read the text from file.
FileStream rtlText = new FileStream(Path.GetFullPath("../../../Arabic.txt"), FileMode.Open, FileAccess.Read);
StreamReader reader = new StreamReader(rtlText);
string text = reader.ReadToEnd();
reader.Dispose();

//Draw string with right-to-left format.
graphics.DrawString(text, font, PdfBrushes.Black, new RectangleF(0, 0, page.GetClientSize().Width, page.GetClientSize().Height), format);

//Set left-to-right text direction for RTL text.
format.TextDirection = PdfTextDirection.LeftToRight;

//Set the text alignment.
format.Alignment = PdfTextAlignment.Left;

//Draw string with left-to-right format.
graphics.DrawString(text, font, PdfBrushes.Black, new RectangleF(0, 100, page.GetClientSize().Width, page.GetClientSize().Height), format);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
