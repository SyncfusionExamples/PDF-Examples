using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;


//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Set the page size.
    document.PageSettings.Size = PdfPageSize.A4;

    //Add a page to the document.
    PdfPage page = document.Pages.Add();

    //Create PDF graphics for the page.
    PdfGraphics graphics = page.Graphics;

    //Set the font.
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

    //Draw the text.
    graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(0, 0));

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
