using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System.Runtime.InteropServices;

// Initialize the HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
// Initialize BlinkConverterSettings to configure the Blink rendering engine.
BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();
// Enables automatic scaling to adjust the HTML content to fit the PDF's dimensions.
blinkConverterSettings.EnableAutoScaling = true;
// Assigns the Blink settings to the HTML to PDF converter.
htmlConverter.ConverterSettings = blinkConverterSettings;
// Converts the HTML file to a PDF document, using the path of the HTML file.
PdfDocument document = htmlConverter.Convert(Path.GetFullPath(@"Data/Input.html"));
// Save the generated PDF document to a specified output file.
using (FileStream fileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create))
{
    document.Save(fileStream);
}
// Close the document.
document.Close(true);
