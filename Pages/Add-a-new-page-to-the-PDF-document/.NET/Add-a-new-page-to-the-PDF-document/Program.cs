// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a new page.
PdfPage page = document.Pages.Add();

//Create PDF graphics for the page.
PdfGraphics graphics = page.Graphics;

//Create a solid brush.
PdfBrush brush = new PdfSolidBrush(Syncfusion.Drawing.Color.Black);

//Set the font.
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 14);

//Draw the text.
graphics.DrawString("Hello world!", font, brush, new Syncfusion.Drawing.PointF(20, 20));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);

