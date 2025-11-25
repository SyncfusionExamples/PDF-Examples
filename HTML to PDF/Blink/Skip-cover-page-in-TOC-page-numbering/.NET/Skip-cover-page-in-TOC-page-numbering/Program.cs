using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

// Create an instance of HTML-to-PDF converter
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
// Configure Blink converter settings
BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings()
{
    ViewPortSize = new Size(1280, 0), // Set viewport width for rendering
    EnableToc = true,                 // Enable Table of Contents (TOC)
};
// Set TOC starting page number to skip the cover page
blinkConverterSettings.Toc.StartingPageNumber = 1;
// Apply the settings to the converter
htmlConverter.ConverterSettings = blinkConverterSettings;
// Read the main HTML content and convert it to PDF
string inputhtml = File.ReadAllText(Path.GetFullPath(@"Data/input.html"));
PdfDocument document = htmlConverter.Convert(inputhtml, "");
//Create cover page and insert to the 0th index.
// Apply scaling settings for the cover page
htmlConverter.ConverterSettings = new BlinkConverterSettings()
{
    Scale = 1.5f
};
// Convert the cover page HTML to PDF
string coverimage = File.ReadAllText(Path.GetFullPath(@"Data/coverpage.html"));
PdfDocument coverPage = htmlConverter.Convert(coverimage, "");
// Insert the cover page at the beginning of the main document
document.Pages.Insert(0, coverPage.Pages[0]);
// Save the PDF document
document.Save(Path.GetFullPath(@"Output/Output.pdf"));
//Dispose the document
coverPage.Close(true);
document.Close(true);
htmlConverter.Close();