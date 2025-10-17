using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    // Add a page to the document.
    PdfPage page = document.Pages.Add();

    // Get graphics context of the added page.
    PdfGraphics graphics = page.Graphics;

    // Define the rectangle dimensions.
    float rectWidth = 416;
    float rectHeight = 145;

    // Calculate the top-center position.
    float pageWidth = page.GetClientSize().Width;
    float rectX = (pageWidth - rectWidth) / 2; // Centered horizontally
    float rectY = 50; // Distance from the top

    // Define the rectangle path.
    PdfPath path = new PdfPath();
    path.AddRectangle(new RectangleF(rectX, rectY, rectWidth, rectHeight));

    // Define gradient colors using RGB (byte values from 0 to 255).
    List<PdfColor> finalGradientColors = new List<PdfColor>
{
    new PdfColor(0, 63, 255),     // Blue
    new PdfColor(0, 200, 83),     // Green
    new PdfColor(255, 193, 7),    // Amber
    new PdfColor(255, 0, 139)     // Magenta
};

    // Define positions for the gradient colors.
    List<float> finalGradientPositions = new List<float> { 0, 0.2f, 0.8f, 1 };

    // Create a color blend object for the gradient.
    PdfColorBlend gradientColorBlend = new PdfColorBlend
    {
        Colors = finalGradientColors.ToArray(),
        Positions = finalGradientPositions.ToArray()
    };

    // Calculate the center point and radius for the radial gradient.
    PointF center = new PointF(rectX + rectWidth / 2, rectY + rectHeight / 2);
    float radius = (float)Math.Sqrt((rectWidth * rectWidth) + (rectHeight * rectHeight)) / 2;

    // Create and configure the radial gradient brush.
    PdfRadialGradientBrush rectangleGradientBrush = new PdfRadialGradientBrush(
        center, 0, center, radius,
        finalGradientColors[0],
        finalGradientColors[finalGradientColors.Count - 1]
    )
    {
        InterpolationColors = gradientColorBlend
    };

    // Draw the gradient-filled rectangle.
    graphics.DrawPath(rectangleGradientBrush, path);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
