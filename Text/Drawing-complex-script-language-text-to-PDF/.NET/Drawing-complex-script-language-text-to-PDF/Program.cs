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

//Get stream from font file.
FileStream fontStream = new FileStream(Path.GetFullPath("../../../tahoma.ttf"), FileMode.Open, FileAccess.Read);

//Create a new PDF font instance.
PdfFont pdfFont = new PdfTrueTypeFont(fontStream, 10);

//Set the format for string.
PdfStringFormat format = new PdfStringFormat();

//Set the format as complex script layout type.
format.ComplexScript = true;

//Draw the text.
graphics.DrawString("สวัสดีชาวโลก", pdfFont, PdfBrushes.Black, new RectangleF(0, 0, page.GetClientSize().Width, page.GetClientSize().Height), format);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream
    document.Save(outputFileStream);
}

//Close the document
document.Close(true);