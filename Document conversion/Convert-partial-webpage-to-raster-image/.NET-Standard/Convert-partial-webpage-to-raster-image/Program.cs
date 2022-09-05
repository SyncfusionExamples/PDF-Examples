// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;

//Initialize HTML converter with WebKit rendering engine.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

//Convert Partial HTML to Image.
Image image = htmlConverter.ConvertPartialHtmlToImage("http://www.google.com", "lga");

//Get the image data.
byte[] imageByte = image.ImageData;

//Save the image.
File.WriteAllBytes(Path.GetFullPath("../../../Output.jpg"), imageByte);
