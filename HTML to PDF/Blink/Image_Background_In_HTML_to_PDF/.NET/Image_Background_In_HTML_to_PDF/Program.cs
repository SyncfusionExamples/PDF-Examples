
using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;
using System.Runtime.InteropServices;

//Initialize HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

//Initialize the BlinkConverterSettings
BlinkConverterSettings settings = new BlinkConverterSettings();

//Set the Image Background color.
settings.ImageBackgroundColor = Color.Transparent;

//Assign the BlinkConverterSettings to the ConverterSettings property of HtmlToPdfConverter.
htmlConverter.ConverterSettings = settings;

//Convert HTML to Image
Image image = htmlConverter.ConvertToImage("file:///D:/PDF-Examples/HTML%20to%20PDF/Blink/Image_Background_In_HTML_to_PDF/.NET/Image_Background_In_HTML_to_PDF/Data/Input.html");

//Save the Image.
byte[] imageByte = image.ImageData;

File.WriteAllBytes(Path.GetFullPath(@"Output/Output.png"), imageByte);


