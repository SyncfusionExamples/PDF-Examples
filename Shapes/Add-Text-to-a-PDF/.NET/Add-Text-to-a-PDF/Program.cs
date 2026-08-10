using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document
using (PdfDocument document = new PdfDocument())
{
    //Add a page to the document
    PdfPage page = document.Pages.Add();
    //Initialize a font and brush for the text
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 14f);
    PdfBrush brush = new PdfSolidBrush(Color.Black);
    //Draw the text on the page
    page.Graphics.DrawString("Hello, World!", font, brush, new PointF(10, 10));
    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}