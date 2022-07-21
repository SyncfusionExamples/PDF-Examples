// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream inputStreamPath = new FileStream(Path.GetFullPath(@"../../../Input.pdf"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputStreamPath);

//Get first page from document
PdfLoadedPage page = loadedDocument.Pages[0] as PdfLoadedPage;

//Create PDF graphics for the page.
PdfGraphics graphics = page.Graphics;

//Set the standard font.
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

//Draw the text.
graphics.DrawString("Hello World!!!", font, PdfBrushes.Red, new PointF(0, 0));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
