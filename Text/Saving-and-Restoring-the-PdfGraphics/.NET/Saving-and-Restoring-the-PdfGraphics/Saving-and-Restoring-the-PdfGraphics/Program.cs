// Create a new PDF document
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;

using (PdfDocument pdfDocument = new PdfDocument())
{
    PdfPage page = pdfDocument.Pages.Add();
    // Create PDF graphics
    PdfGraphics graphics = page.Graphics;
    // Save the current graphics state and apply transformations
    graphics.Save();
    graphics.TranslateTransform(100, 50);
    graphics.RotateTransform(45);
    // Define the font for drawing text
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 16);
    // Draw transformed text
    graphics.DrawString("Hello, World!", font, PdfBrushes.Black, new PointF(0, 0));
    // Restore the previous graphics state to ensure subsequent text is unaffected
    graphics.Restore();
    // Draw text that is not influenced by transformations
    graphics.DrawString("This text is not rotated.", font, PdfBrushes.Black, new PointF(0, 100));
    using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
    {
        //Save the PDF document to file stream.
        pdfDocument.Save(outputFileStream);
    }
    pdfDocument.Close(true);
}