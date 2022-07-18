// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Disable unique resource naming.
PdfDocument.EnableUniqueResourceNaming = false;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a page to the document.
PdfPage page = document.Pages.Add();

//Create PDF graphics for the page.
PdfGraphics graphics = page.Graphics;

//Create new instance for PDF font.
PdfFont font1 = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

//Draw the text with Helvetica standard font. 
graphics.DrawString("Hello World!!!", font1, PdfBrushes.BlueViolet, new PointF(50, 50));

//Create new instance for PDF font from TTF file. 
FileStream fontStream = new FileStream("../../../Arial.ttf", FileMode.Open, FileAccess.Read);
PdfFont font2 = new PdfTrueTypeFont(fontStream, 20);

//Draw the text with Arial font. 
graphics.DrawString("Hello World!!!", font2, PdfBrushes.OrangeRed, new PointF(50, 100));

//Create new instance for PDF Japanese font. 
PdfFont font3 = new PdfCjkStandardFont(PdfCjkFontFamily.HeiseiMinchoW3, 20);

//Draw the text with Japanese font. 
graphics.DrawString("こんにちは世界", font3, PdfBrushes.GreenYellow, new PointF(50, 150));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the PDF document.
document.Close(true);
