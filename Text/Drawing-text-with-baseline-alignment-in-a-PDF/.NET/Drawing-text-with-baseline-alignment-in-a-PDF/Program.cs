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

//Get stream from font stream. 
FileStream fontStream1 = new FileStream(Path.GetFullPath("../../../tahoma.ttf"), FileMode.Open, FileAccess.Read);
FileStream fontStream2 = new FileStream(Path.GetFullPath("../../../Arial.ttf"), FileMode.Open, FileAccess.Read);
FileStream fontStream3 = new FileStream(Path.GetFullPath("../../../Calibri.ttf"), FileMode.Open, FileAccess.Read);

//Create a new PDF font instance.
PdfFont font = new PdfTrueTypeFont(fontStream1, 8);
PdfFont font1 = new PdfTrueTypeFont(fontStream2, 20);
PdfFont font2 = new PdfStandardFont(PdfFontFamily.Helvetica, 16);
PdfFont font3 = new PdfTrueTypeFont(fontStream3, 25);

//Set the format for string.
PdfStringFormat format = new PdfStringFormat();

//Set the line alignment.
format.LineAlignment = PdfVerticalAlignment.Bottom;

//Set baseline for the line alignment.
format.EnableBaseline = true;

//Draw the text.
graphics.DrawString("Hello World!", font, PdfBrushes.Black, new PointF(0, 50), format);
graphics.DrawString("Hello World!", font1, PdfBrushes.Black, new PointF(65, 50), format);
graphics.DrawString("Hello World!", font2, PdfBrushes.Black, new PointF(220, 50), format);
graphics.DrawString("Hello World!", font3, PdfBrushes.Black, new PointF(320, 50), format);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);