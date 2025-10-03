using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.HtmlToPdf;
using Syncfusion.Pdf;

// Initialize the HTML to PDF converter with Blink rendering engine
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter(HtmlRenderingEngine.Blink);

// Create Blink converter settings
BlinkConverterSettings settings = new BlinkConverterSettings
{
    EnableToc = true
};
using (FileStream fontStream = new FileStream(Path.GetFullPath(@"Data/ARIALUNI.TTF"), FileMode.Open, FileAccess.Read))
{
    // Load a Unicode TrueType font from system or custom path
    PdfTrueTypeFont unicodeFont = new PdfTrueTypeFont(fontStream, 14);

    // Set the style for level 1 (H1) items in table of contents
    HtmlToPdfTocStyle tocStyleH1 = new HtmlToPdfTocStyle
    {
        Font = unicodeFont,
        BackgroundColor = new PdfSolidBrush(new PdfColor(Color.FromArgb(68, 114, 196))),
        ForeColor = PdfBrushes.White,
        Padding = new PdfPaddings(5, 5, 3, 3)
    };

    // Apply the style to TOC level 1
    settings.Toc.SetItemStyle(1, tocStyleH1);

    // Assign Blink converter settings to HTML converter
    htmlConverter.ConverterSettings = settings;

    // Convert HTML to PDF
    PdfDocument document = htmlConverter.Convert(Path.GetFullPath(@"Data/Input.html"));

    //Save the PDF document
    document.Save(fileStream);
    //Close the PDF document
    document.Close(true);
}
