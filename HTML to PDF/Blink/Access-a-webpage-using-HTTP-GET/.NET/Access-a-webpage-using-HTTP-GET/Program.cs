// See https://aka.ms/new-console-template for more information

using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System.Runtime.InteropServices;

//Initialize the HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();
if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
{
    //Set command line arugument to run without the sandbox.
    blinkConverterSettings.CommandLineArguments.Add("--no-sandbox");
    blinkConverterSettings.CommandLineArguments.Add("--disable-setuid-sandbox");
}
//Assign Blink converter settings to HTML converter.
htmlConverter.ConverterSettings = blinkConverterSettings;

//Set the URL. 
string url = "https://www.example.com";
Uri getMethodUri = new Uri(url);

//Passed the parameter in string. 
string httpGetData = getMethodUri.Query.Length > 0 ? "&" : "?" + String.Format("{0}={1}", "firstName", "Andrew");
httpGetData += String.Format("&{0}={1}", "lastName", "Fuller");
string urlToConvert = url + httpGetData;

//Convert URL to PDF document. 
PdfDocument document = htmlConverter.Convert(urlToConvert);

//Create file stream. 
FileStream fileStream = new FileStream(Path.GetFullPath(@"Output/HTML-to-PDF.pdf"), FileMode.CreateNew, FileAccess.ReadWrite);

//Save and close the PDF document 
document.Save(fileStream);
document.Close(true);
