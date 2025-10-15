using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page to the document.
    PdfPage page = document.Pages.Add();

    //Create PDF graphics for the page.
    PdfGraphics graphics = page.Graphics;

    //Set the font.
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

    //Draw the text.
    graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(0, 0));

    //Show the attachments panel.
    document.ViewerPreferences.PageMode = PdfPageMode.UseAttachments;

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}