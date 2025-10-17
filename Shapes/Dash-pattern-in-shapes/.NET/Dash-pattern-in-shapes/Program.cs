using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    // Add a page to the document
    PdfPage page = document.Pages.Add();

    // Create a PdfGraphics object to draw on the page
    PdfGraphics graphics = page.Graphics;

    // Create a custom dashed line pattern (5-point dash, 2-point gap)
    float[] dashPattern = { 5, 2 }; // Dash length, gap length

    // Create a PdfPen with the dash pattern and color
    PdfPen dashPen = new PdfPen(PdfBrushes.Black, 2);  // 2 is the line width

    // Set the DashStyle to Custom before applying DashPattern
    dashPen.DashStyle = PdfDashStyle.Custom;  // Use Custom style to enable DashPattern
    dashPen.DashPattern = dashPattern;

    // Draw a line with the custom dash pattern
    graphics.DrawLine(dashPen, new Syncfusion.Drawing.PointF(10, 10), new PointF(300, 10));

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}