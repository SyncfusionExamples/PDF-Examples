// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;

//Initialize HTML to PDF converter with Blink rendering engine.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter(HtmlRenderingEngine.Blink);

//Convert URL to Image.
Image image = htmlConverter.ConvertToImage("https://www.google.com");

//Get image bytes. 
byte[] imageByte = image.ImageData;

//Save the image.
File.WriteAllBytes(Path.GetFullPath("../../../Output.jpg"), imageByte);
