using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;

// Initialize HTML to PDF converter
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
// Initialize Blink converter settings
BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();

// Set the crop region for the HTML conversion based on the bounds of the HTML file
blinkConverterSettings.CropRegion = htmlConverter.GetHtmlBounds(Path.GetFullPath(@"Data\Input.html"));

// Assign Blink converter settings to the HTML converter
htmlConverter.ConverterSettings = blinkConverterSettings;
// Convert the HTML file to an image
Image image = htmlConverter.ConvertToImage(Path.GetFullPath(@"Data\Input.html"));
// Save the image as a PNG file
File.WriteAllBytes(Path.GetFullPath(@"Output\Output.png"), image.ImageData);