// See https://aka.ms/new-console-template for more information

using Syncfusion.HtmlConverter;

//Initialize the HTML converter with the WebKit rendering engine.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter(HtmlRenderingEngine.WebKit);

//Initialize the memory stream.
MemoryStream stream = new MemoryStream();

//Convert URL to SVG.
htmlConverter.ConvertToSvg("http://www.syncfusion.com", stream);

//Save the SVG file to disk. 
using (FileStream output = new FileStream(Path.GetFullPath("../../../Sample.svg"), FileMode.Create))
{
    stream.CopyTo(output);
}
