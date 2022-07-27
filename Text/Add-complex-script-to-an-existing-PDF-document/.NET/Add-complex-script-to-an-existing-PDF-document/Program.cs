// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream inputFileStream = new FileStream(Path.GetFullPath(@"../../../Input.pdf"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

//Load a PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputFileStream);

//Get first page from the document.
PdfLoadedPage page = loadedDocument.Pages[0] as PdfLoadedPage;

//Create PDF graphics for the page.
PdfGraphics graphics = page.Graphics;

//Get stream from the font file. 
FileStream fontStream = new FileStream(Path.GetFullPath("../../../tahoma.ttf"), FileMode.Open, FileAccess.Read);

//Create a new PDF font instance. 
PdfFont pdfFont = new PdfTrueTypeFont(fontStream, 10);

//Set the format for string.
PdfStringFormat format = new PdfStringFormat();

//Set the format as complex script layout type.
format.ComplexScript = true;

//Draw the text.
graphics.DrawString("สวัสดีชาวโลก", pdfFont, PdfBrushes.Black, new RectangleF(0, 0, page.Size.Width, page.Size.Height), format);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
