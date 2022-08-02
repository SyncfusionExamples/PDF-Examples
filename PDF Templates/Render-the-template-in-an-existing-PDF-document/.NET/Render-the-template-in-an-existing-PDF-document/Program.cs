// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Load the page into Pdf document.
PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

//Create a PDF Template.
PdfTemplate template = new PdfTemplate(100, 50);

//Draw a rectangle on the template graphics.
template.Graphics.DrawRectangle(PdfBrushes.BurlyWood, new Syncfusion.Drawing.RectangleF(0, 0, 100, 50));

//Create the font. 
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 14);

//Create the brush. 
PdfBrush brush = new PdfSolidBrush(Syncfusion.Drawing.Color.Black);

//Draw a string on the graphics of the template.
template.Graphics.DrawString("Hello World", font, brush, 5, 5);

//Draw the template on the page graphics of the document.
loadedPage.Graphics.DrawPdfTemplate(template, Syncfusion.Drawing.PointF.Empty);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
