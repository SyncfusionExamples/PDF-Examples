using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page to the PDF document.
    PdfPage pdfPage = document.Pages.Add();

    //Create graphics for the PDF page. 
    PdfGraphics graphics = pdfPage.Graphics;

    //Set the font.
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

    //Watermark text.
    PdfGraphicsState state = graphics.Save();

    //Set the trasparency and rotate transform for the page graphics. 
    graphics.SetTransparency(0.25f);
    graphics.RotateTransform(-40);

    //Draw the text in the PDF document. 
    graphics.DrawString("Imported using Essential PDF", font, PdfPens.Red, PdfBrushes.Red, new PointF(-150, 450));

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}