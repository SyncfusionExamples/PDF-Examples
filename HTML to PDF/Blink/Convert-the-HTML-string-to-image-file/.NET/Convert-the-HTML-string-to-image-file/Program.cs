// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;

//Initialize HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

//HTML string and Base URL.
string htmlText = "<html><body><img src=\"syncfusion_logo.png\" alt=\"Syncfusion_logo\" width=\"200\" height=\"70\"><p> Hello World</p></body></html>";
string baseUrl = Path.GetFullPath("../../../Resources/");

//Convert HTML string to Image.
Image image = htmlConverter.ConvertToImage(htmlText, baseUrl);

//Get image bytes. 
byte[] imageByte = image.ImageData;

//Save the image.
File.WriteAllBytes(Path.GetFullPath("../../../Output.jpg"), imageByte);
