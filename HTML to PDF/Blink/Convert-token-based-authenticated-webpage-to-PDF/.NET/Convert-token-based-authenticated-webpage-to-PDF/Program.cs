// See https://aka.ms/new-console-template for more information

using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System.Runtime.InteropServices;

//Initialize HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

//Initialize blink converter settings.
BlinkConverterSettings settings = new BlinkConverterSettings();

//Add a bearer token to login a webpage.
settings.HttpRequestHeaders.Add("User-Agent", "Syncfusion WebKit HTML converter");

//Assign Blink settings to HTML converter.
htmlConverter.ConverterSettings = settings;

//Convert URL to PDF document. 
PdfDocument document = htmlConverter.Convert("https://httpbin.org/headers");

//Create file stream. 
using (FileStream fileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document 
    document.Save(fileStream);
}
//Close the document.
document.Close(true);
