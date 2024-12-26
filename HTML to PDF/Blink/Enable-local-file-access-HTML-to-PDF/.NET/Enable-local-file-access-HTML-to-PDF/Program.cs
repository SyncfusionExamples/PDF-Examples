
using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

// Initialize HTML to PDF converter with a using statement to ensure disposal
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

// Initialize Blink converter settings
BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();
// Set Blink viewport size
blinkConverterSettings.ViewPortSize = new Size(1280, 0);

// EnableLocalFileAccess=false restricts external CSS and images in local HTML content
blinkConverterSettings.EnableLocalFileAccess = false;

// Assign Blink converter settings to HTML converter
htmlConverter.ConverterSettings = blinkConverterSettings;
// Read HTML content from file
string html = File.ReadAllText(Path.GetFullPath(@"Data/Sample.html"));
// Convert HTML to PDF document
using (PdfDocument document = htmlConverter.Convert(html, ""))
{
    // Create a file stream with a using statement to ensure disposal
    using (FileStream fileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
    {
        // Save the PDF document to the file stream
        document.Save(fileStream);
    }
}
