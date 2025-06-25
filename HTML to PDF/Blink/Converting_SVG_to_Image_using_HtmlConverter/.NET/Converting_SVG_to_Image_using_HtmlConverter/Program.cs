using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;

HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
string svg = File.ReadAllText(Path.GetFullPath(@"Data/Input.svg"));
Image images = htmlConverter.ConvertToImage(svg, "");
byte[] imageByte = images.ImageData;
//Save the image
File.WriteAllBytes(Path.GetFullPath(@"Output/Output.jpg"), imageByte);