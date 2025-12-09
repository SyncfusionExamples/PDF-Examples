using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

// Create the new PDF document
using (PdfDocument document = new PdfDocument())
{
    // Add a new page to the document
    PdfPage page = document.Pages.Add();
    // Get the client size
    SizeF clientSize = page.GetClientSize();
    // Load the background image from disk
    using FileStream imageStream = new FileStream(
        Path.GetFullPath(@"Data/Image.jpg"),
        FileMode.Open,
        FileAccess.Read
    );
    PdfBitmap image = new PdfBitmap(imageStream);
    // Save the current graphics state, apply transparency, draw the image to cover the page, then restore.
    PdfGraphicsState state = page.Graphics.Save();
    page.Graphics.SetTransparency(0.2f); // 20% opacity for the background image
    page.Graphics.DrawImage(
        image,
        new PointF(0, 0),
        new SizeF(clientSize.Width, clientSize.Height)
    );
    page.Graphics.Restore(state);
    // Define a small margin for the text content.
    const float margin = 10f;
    // Text bounds: fill the page within margins.
    RectangleF textBounds = new RectangleF(
        margin,
        margin,
        clientSize.Width - margin * 2,
        clientSize.Height - margin * 2
    );
    // Body font for the paragraph.
    PdfFont bodyFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 16, PdfFontStyle.Regular);
    // Sample paragraph text.
    string paragraphText =
        "Adventure Works Cycles, the fictitious company on which the AdventureWorks sample databases " +
        "are based, is a large, multinational manufacturing company. The company manufactures and sells " +
        "metal and composite bicycles to North American, European and Asian commercial markets. While " +
        "its base operation is located in Washington with 290 employees, several regional sales teams " +
        "are located throughout their market base.";
    // Create a text element and configure layout to paginate if content exceeds current page.
    PdfTextElement textElement = new PdfTextElement(paragraphText, bodyFont, PdfBrushes.Black);
    PdfLayoutFormat layoutFormat = new PdfLayoutFormat
    {
        Break = PdfLayoutBreakType.FitPage, // Fit within page bounds
        Layout = PdfLayoutType.Paginate      // Continue to subsequent pages if needed
    };
    // Draw the text paragraph in the defined bounds.
    textElement.Draw(page, textBounds, layoutFormat);
    // Save the PDF document to disk.
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
