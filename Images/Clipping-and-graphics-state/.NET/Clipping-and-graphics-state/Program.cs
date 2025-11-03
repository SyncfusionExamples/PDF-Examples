using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

// Create a new PDF document
using (PdfDocument document = new PdfDocument())
{
    // Add a page to the document
    PdfPage page = document.Pages.Add();
    // Get the graphics object for the page
    PdfGraphics graphics = page.Graphics;
    // Open the image file as a stream
    using FileStream imageStream = new FileStream(Path.GetFullPath(@"Data/Input.png"), FileMode.Open, FileAccess.Read);
    // Load the image from the stream
    PdfBitmap image = new PdfBitmap(imageStream);
    // Save the current graphics state (to restore later)
    PdfGraphicsState state = graphics.Save();
    // Define a rectangular clipping region
    RectangleF clipRect = new RectangleF(50, 50, 200, 100);
    graphics.SetClip(clipRect);
    // Draw the image — only the part within the clipping region will be visible
    graphics.DrawImage(image, new RectangleF(40, 60, 150, 80));
    // Restore the graphics state to remove the clipping region
    graphics.Restore(state);
    // Draw the image again — this time the full image will be visible
    graphics.DrawImage(image, new RectangleF(60, 160, 150, 80));
    // Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
