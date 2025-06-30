using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;

HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
string svg = File.ReadAllText(Path.GetFullPath(@"Data/Input.svg"));
// Convert the SVG content to an image using the converter
Image image = htmlConverter.ConvertToImage(svg, "");

// Extract the image data as a byte array
byte[] imageBytes = image.ImageData;

// Save the image data to a file in JPEG format
File.WriteAllBytes(Path.GetFullPath(@"Output/Output.jpg"), imageBytes);