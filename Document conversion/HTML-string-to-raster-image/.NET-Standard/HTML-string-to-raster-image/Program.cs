// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;

//Initialize HTML converter with WebKit rendering engine.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

//HTML string and Base URL.
string htmlString = "<html><body>Hello World!!!</body></html>";
string baseURL = "";

//Convert HTML string to Image.
Image image = htmlConverter.ConvertToImage(htmlString, baseURL);
byte[] imageByte = image.ImageData;

//Save the image.
File.WriteAllBytes(Path.GetFullPath("../../../Output.jpg"), imageByte);
