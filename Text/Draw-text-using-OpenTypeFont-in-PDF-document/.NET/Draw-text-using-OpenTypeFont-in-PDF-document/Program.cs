// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a page.
PdfPage page = document.Pages.Add();

//Get stream from OTF font file. 
FileStream fontFileStream = new FileStream(Path.GetFullPath(@"../../../font.otf"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

//Create font. 
PdfFont font = new PdfTrueTypeFont(fontFileStream, 14);

//Text to draw.
string text = "Syncfusion Essential PDF is a.NET Core PDF library used to create, read, and edit PDF files in any application.";

//Create a brush.
PdfBrush brush = new PdfSolidBrush(new PdfColor(0, 0, 0));

//Create a pen.
PdfPen pen = new PdfPen(new PdfColor(0, 0, 0));

//Get page client size.
SizeF clipBounds = page.Graphics.ClientSize;
RectangleF rect = new RectangleF(0, 0, clipBounds.Width, clipBounds.Height);

//Draw the text.
page.Graphics.DrawString(text, font, brush, rect);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
