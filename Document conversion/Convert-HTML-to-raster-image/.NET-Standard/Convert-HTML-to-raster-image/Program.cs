// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;

//Initialize HTML converter with WebKit rendering engine.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

//Convert URL to Image.
Image image = htmlConverter.ConvertToImage("http://www.google.com");

//Get image bytes. 
byte[] imageByte = image.ImageData;

//Save the image.
File.WriteAllBytes(Path.GetFullPath("../../../Output.jpg"), imageByte);
