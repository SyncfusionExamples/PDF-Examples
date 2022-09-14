// See https://aka.ms/new-console-template for more information

using Syncfusion.HtmlConverter;

//Initialize the HTML converter with the WebKit rendering engine.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter(HtmlRenderingEngine.WebKit);

//Initialize the memory stream.
MemoryStream stream = new MemoryStream();

//Convert a partial HTML to SVG.
htmlConverter.ConvertPartialHtmlToSvg(Path.GetFullPath("../../../input.html"), "pic", stream);

//Save the document.
using (FileStream output = new FileStream(Path.GetFullPath("../../../Sample.svg"), FileMode.Create))
{
    stream.Position = 0;
    stream.CopyTo(output);
}
