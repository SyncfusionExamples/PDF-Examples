using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

// Create a new PDF document.
PdfDocument document = new PdfDocument();

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

// Define gradient colors.
List<PdfColor> finalGradientColors = new List<PdfColor>
        {
            new PdfColor(0, 0.247058809f, 1, 0),
            new PdfColor(0, 0.247058809f, 1, 0),
            new PdfColor(1, 0, 0.545454562f, 80),
            new PdfColor(1, 0, 0.545454562f, 80)
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

// Save the PDF document to a file using a file stream.
using (FileStream fs = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.Write))
{
    document.Save(fs);
}

// Close the document and release resources.
document.Close(true);
