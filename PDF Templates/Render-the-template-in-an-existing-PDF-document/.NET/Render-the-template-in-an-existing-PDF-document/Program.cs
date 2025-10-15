using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
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

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
