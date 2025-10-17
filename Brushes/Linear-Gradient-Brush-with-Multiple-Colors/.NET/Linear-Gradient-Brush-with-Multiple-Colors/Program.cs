
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using System.Reflection.Metadata;

// Create a new PDF document
using (PdfDocument document = new PdfDocument())
{
    // Add a page to the document
    PdfPage page = document.Pages.Add();

    // Create PDF graphics for the page
    PdfGraphics graphics = page.Graphics;

    // Create a new PDF linear gradient brush
    PdfLinearGradientBrush brush = new PdfLinearGradientBrush(
        new RectangleF(new PointF(0, 0), new SizeF(200, 100)),
        Color.Red, Color.Blue,
        PdfLinearGradientMode.Horizontal
    );

    // Create and configure the color blend
    PdfColorBlend colorBlend = new PdfColorBlend(4)
    {
        // Define the colors for the gradient
        Colors = new PdfColor[]
        {
            Color.Red,
            Color.Yellow,
            Color.Green,
            Color.Blue
        },

        // Define the position of each color in the gradient
        Positions = new float[] { 0, 0.3f, 0.7f, 1 }
    };

    // Apply the color blend to the linear gradient brush
    brush.InterpolationColors = colorBlend;

    // Draw a rectangle filled with the gradient
    graphics.DrawRectangle(brush, new RectangleF(0, 0, 200, 100));

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}