using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;

// Create a new PDF document
using (PdfDocument document = new PdfDocument())
{
    // Add a page
    PdfPage page = document.Pages.Add();

    // Initialize unit converter
    PdfUnitConverter converter = new PdfUnitConverter();

    // Convert margins from inches to points
    float margin = converter.ConvertUnits(1f, PdfGraphicsUnit.Inch, PdfGraphicsUnit.Point);

    // Define text bounds to fill the page with margins
    RectangleF textBounds = new RectangleF(
        margin,
        margin,
        page.Graphics.ClientSize.Width - 2 * margin,
        page.Graphics.ClientSize.Height - 2 * margin
    );

    // Define font and paragraph text
    PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 14);

    string paragraphText = "Adventure Works Cycles, the fictitious company on which the AdventureWorks sample databases are based, is a large, multinational manufacturing company. The company manufactures and sells metal and composite bicycles to North American, European and Asian commercial markets. While its base operation is located in Washington with 290 employees, several regional sales teams are located throughout their market base.";

    // Create text element and layout format
    PdfTextElement textElement = new PdfTextElement(paragraphText, font, PdfBrushes.Black);

    PdfLayoutFormat layoutFormat = new PdfLayoutFormat
    {
        Break = PdfLayoutBreakType.FitPage,
        Layout = PdfLayoutType.Paginate
    };

    // Draw the paragraph text within the bounds
    textElement.Draw(page, textBounds, layoutFormat);

    //Save the document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
