using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

//Create a new PDF document
using (PdfDocument document = new PdfDocument())
{
    //Add a page to the document
    PdfPage page = document.Pages.Add();
    // Create a standard font
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
    //Draw the text using page graphics
    page.Graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));
    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}