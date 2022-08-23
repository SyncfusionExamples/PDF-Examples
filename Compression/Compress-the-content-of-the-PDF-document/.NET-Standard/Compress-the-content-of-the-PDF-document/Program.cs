// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Set the compression level to best
document.Compression = PdfCompressionLevel.Best;

//Add a page to the document.
PdfPage page = document.Pages.Add();

//Create PDF graphics for the page.
PdfGraphics graphics = page.Graphics;

//Set the font.
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

string text = "Hello World!!!";
PdfTextElement textElement = new PdfTextElement(text, font);

PdfLayoutResult result = textElement.Draw(page, new RectangleF(0, 0, font.MeasureString(text).Width, page.GetClientSize().Height));

for (int i = 0; i < 1000; i++)
{
    result = textElement.Draw(result.Page, new RectangleF(0, result.Bounds.Bottom + 10, font.MeasureString(text).Width, page.GetClientSize().Height));
}

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);