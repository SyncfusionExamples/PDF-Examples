// See https://aka.ms/new-console-template for more information
 
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

//Initialize HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter(HtmlRenderingEngine.WebKit);

WebKitConverterSettings settings = new WebKitConverterSettings();

//Add a bearer token to login a webpage.
settings.HttpRequestHeaders.Add("User-Agent", "Syncfusion WebKit HTML converter");

//Assign WebKit settings to HTML converter.
htmlConverter.ConverterSettings = settings;

//Convert URL to PDF document. 
PdfDocument document = htmlConverter.Convert("https://httpbin.org/headers");

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);

