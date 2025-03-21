using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System.Text;

byte[] CreatePdfFromUrl(string url, CefConverterSettings settings)
{
    var converter = new HtmlToPdfConverter()
    {
        RenderingEngine = HtmlRenderingEngine.Cef,
        ConverterSettings = settings,
    };

    using (var document = converter.Convert(url))
    {
        var stream = new MemoryStream();
        document.Save(stream);
        stream.Position = 0;
        return stream.ToArray();
    }
}

// Example usage:
string url = "http://google.com";
var bytes = CreatePdfFromUrl(url, new CefConverterSettings()
{
    AdditionalDelay = 5000,
    ViewPortSize = new Syncfusion.Drawing.Size(1920, 1080),
    Orientation = PdfPageOrientation.Landscape,
    Scale = 0.7f,
    EnableJavaScript = true,
    EnableHyperLink = false,
    HtmlEncoding = Encoding.UTF8
});
//Save the PDF document.
File.WriteAllBytes(Path.GetFullPath(@"Output/Output.pdf"), bytes);
