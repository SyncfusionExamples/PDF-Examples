// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;
using System.Runtime.InteropServices;

//Initialize HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();
if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
{
    //Set command line arugument to run without the sandbox.
    blinkConverterSettings.CommandLineArguments.Add("--no-sandbox");
    blinkConverterSettings.CommandLineArguments.Add("--disable-setuid-sandbox");
}
//Assign Blink converter settings to HTML converter.
htmlConverter.ConverterSettings = blinkConverterSettings;
//Convert URL to Image.
Image image = htmlConverter.ConvertToImage("https://www.google.com");

//Get image bytes. 
byte[] imageByte = image.ImageData;

//Save the image.
File.WriteAllBytes(Path.GetFullPath(@"Output/Output.jpg"), imageByte);

