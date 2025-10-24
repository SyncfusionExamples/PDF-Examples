using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new document.
using (PdfDocument document = new PdfDocument())
{
    //Diable the font cache
    PdfDocument.EnableCache = false;

    //Creates a new page and adds it as the last page of the document
    PdfPage page = document.Pages.Add();
    //Create Pdf graphics for the page
    PdfGraphics graphics = page.Graphics;
    //Create a solid brush
    PdfBrush brush = new PdfSolidBrush(Color.Black);
    float fontSize = 20f;
    //Set the font
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, fontSize);
    //Draw the text
    graphics.DrawString("Hello world!", font, brush, new PointF(20, 20));
    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}