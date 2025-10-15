using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a section.
    PdfSection section = document.Sections.Add();

    //Rotate a section/page to 90 degree. 
    section.PageSettings.Rotate = PdfPageRotateAngle.RotateAngle90;

    //Add page to the section.
    PdfPage page = section.Pages.Add();

    //Create PDF graphics for the page.
    PdfGraphics graphics = page.Graphics;

    //Create a solid brush.
    PdfBrush brush = new PdfSolidBrush(Color.Black);

    //Set the font.
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 14);

    //Draws the text.
    graphics.DrawString("Rotated by 90 degree", font, brush, new PointF(20, 20));

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

