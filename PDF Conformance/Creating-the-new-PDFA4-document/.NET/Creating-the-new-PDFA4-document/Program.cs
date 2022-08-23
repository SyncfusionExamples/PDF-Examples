// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new document with the PDF/A-4 standard. 
PdfDocument document = new PdfDocument(PdfConformanceLevel.Pdf_A4);

//Add a page to the document. 
PdfPage page = document.Pages.Add();

//Create the PDF graphics for the page. 
PdfGraphics graphics = page.Graphics;

//Get stream from the font file.  
FileStream fontStream = new FileStream(Path.GetFullPath("../../../Arial.ttf"), FileMode.Open, FileAccess.Read);

//Load the TrueType font from the local file. 
PdfFont font = new PdfTrueTypeFont(fontStream, 14);

//Draw the text.
graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(0, 0));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);