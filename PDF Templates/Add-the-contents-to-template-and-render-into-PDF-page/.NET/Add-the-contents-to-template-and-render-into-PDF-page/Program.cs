// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
PdfDocument pdfDocument = new PdfDocument();

//Add a page to the PDF document.
PdfPage pdfPage = pdfDocument.Pages.Add();

//Create a PDF Template.
PdfTemplate template = new PdfTemplate(100, 50);

//Draw a rectangle on the template graphics.
template.Graphics.DrawRectangle(PdfBrushes.BurlyWood, new Syncfusion.Drawing.RectangleF(0, 0, 100, 50));

//Create the font.
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 14);

//Create the brush. 
PdfBrush brush = new PdfSolidBrush(Color.Black);

//Draw a string using the graphics of the template.
template.Graphics.DrawString("Hello World", font, brush, 5, 5);

//Draw the template on the page graphics of the document.
pdfPage.Graphics.DrawPdfTemplate(template, PointF.Empty);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    pdfDocument.Save(outputFileStream);
}

//Close the document.
pdfDocument.Close(true);
