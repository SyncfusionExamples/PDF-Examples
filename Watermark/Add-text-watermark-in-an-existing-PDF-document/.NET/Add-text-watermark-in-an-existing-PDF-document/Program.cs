using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Load the PDF document
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Get the first page of the PDF document
    PdfPageBase loadedPage = loadedDocument.Pages[0];
    //Create the standard font
    PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 32);
    // Measure the watermark text and get the size
    string watermarkText = "Created using Syncfusion PDF library";
    SizeF watermarkTextSize = font.MeasureString(watermarkText);
    // Move the graphics to the center of the page
    loadedPage.Graphics.Save();
    loadedPage.Graphics.TranslateTransform(loadedPage.Size.Width / 2, loadedPage.Size.Height / 2);
    // Rotate the graphics to 45 degrees
    loadedPage.Graphics.RotateTransform(-45);
    //Set transparency
    loadedPage.Graphics.SetTransparency(0.25f);
    // Draw the watermark text
    loadedPage.Graphics.DrawString(watermarkText, font, PdfBrushes.Red, new PointF(-watermarkTextSize.Width / 2, -watermarkTextSize.Height / 2));
    // Restore the graphics
    loadedPage.Graphics.Restore();
    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}