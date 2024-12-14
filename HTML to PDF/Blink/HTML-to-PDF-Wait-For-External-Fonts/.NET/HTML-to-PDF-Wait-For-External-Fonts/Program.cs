using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

//Initialize HTML to PDF converter
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
// Initialize Blink converter settings
BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();

// Set the converter to wait for external fonts to be loaded before converting
blinkConverterSettings.WaitForExternalFonts = true;
//Assign Blink converter settings to HTML converter
htmlConverter.ConverterSettings = blinkConverterSettings;
//Convert URL to PDF
PdfDocument document = htmlConverter.Convert(Path.GetFullPath(@"Data\Input.html"));

// Create a FileStream to save the PDF document to a file
using (FileStream fileStream = new FileStream(Path.GetFullPath(@"Output\Output.pdf"), FileMode.Create))
{
    // Save the PDF document to the file stream
    document.Save(fileStream);
}
// Close the document after saving
document.Close(true);