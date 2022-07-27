// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Set margin for all the pages.
document.PageSettings.Margins.All = 100;

//Add a page.
PdfPage page = document.Pages.Add();

//Create PDF graphics for the page.
PdfGraphics graphics = page.Graphics;

//Creates a solid brush.
PdfBrush brush = new PdfSolidBrush(Color.Black);

//Set the font.
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 14);

//Draw the text.
graphics.DrawString("Hello world!", font, brush, new PointF(0, 0));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
