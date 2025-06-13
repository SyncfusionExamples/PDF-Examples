using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

// Create a new PDF document.
PdfDocument document = new PdfDocument();

// Add a page to the document.
PdfPage page = document.Pages.Add();

// Create PDF graphics object for the page.
PdfGraphics graphics = page.Graphics;

// Define rectangle dimensions.
float rectWidth = 150f;
float rectHeight = 150f;

// Calculate position to center the rectangle horizontally at the top.
float pageWidth = page.GetClientSize().Width;
float startX = (pageWidth - rectWidth) / 2;
float startY = 60f; // Positioned near the top

// Define the rectangle path.
PdfPath path = new PdfPath();
path.AddRectangle(new RectangleF(startX, startY, rectWidth, rectHeight));

// Define a smooth gradient color scheme.
List<PdfColor> gradientColors = new List<PdfColor>
        {
            Color.CornflowerBlue,
            Color.MediumPurple,
            Color.DeepPink
        };

List<float> gradientPositions = new List<float> { 0.0f, 0.5f, 1.0f };

PdfColorBlend colorBlend = new PdfColorBlend
{
    Colors = gradientColors.ToArray(),
    Positions = gradientPositions.ToArray()
};

// Calculate the radius for the radial gradient.
float radius = (float)Math.Sqrt((rectWidth * rectWidth) + (rectHeight * rectHeight)) / 2;

// Create a radial gradient brush centered in the rectangle.
PointF center = new PointF(startX + rectWidth / 2, startY + rectHeight / 2);
PdfRadialGradientBrush radialBrush = new PdfRadialGradientBrush(center, 0, center, radius, gradientColors[0], gradientColors[gradientColors.Count - 1])
{
    InterpolationColors = colorBlend
};

// Draw the rectangle with the radial gradient fill.
graphics.DrawPath(radialBrush, path);

// Save the document to file.
using (FileStream fileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    document.Save(fileStream);
}

// Close the document.
document.Close(true);