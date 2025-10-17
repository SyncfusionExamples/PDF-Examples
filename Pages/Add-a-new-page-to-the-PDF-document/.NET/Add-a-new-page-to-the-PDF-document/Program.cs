using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
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

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

