// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create the new PDF document. 
PdfDocument document = new PdfDocument();

//Add a page to the document.
PdfPage page = document.Pages.Add();

//Create PDF graphics for the page.
PdfGraphics graphics = page.Graphics;

//Create a new PDF font instance.
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);

string text = "Hello World!";

//Measure the text.
SizeF size = font.MeasureString(text);

//Draw test to the PDF page with measured size. 
graphics.DrawString(text, font, PdfBrushes.Black, new RectangleF(PointF.Empty, size));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);

