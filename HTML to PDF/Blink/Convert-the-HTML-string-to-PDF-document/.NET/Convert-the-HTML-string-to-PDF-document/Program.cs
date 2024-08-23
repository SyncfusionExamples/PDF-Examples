// See https://aka.ms/new-console-template for more information

using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System.Runtime.InteropServices;

//Initialize HTML to PDF converter.
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
//HTML string and Base URL.
string htmlText = "<html><body><img src=\"syncfusion_logo.png\" alt=\"Syncfusion_logo\" width=\"200\" height=\"70\"><p> Hello World</p></body></html>";
string baseUrl = Path.GetFullPath(@"Data/Resources/");

//Convert HTML string to PDF document. 
PdfDocument document = htmlConverter.Convert(htmlText, baseUrl);

//Create the file stream. 
FileStream fileStream = new FileStream(Path.GetFullPath(@"Output/HTML-to-PDF.pdf"), FileMode.CreateNew, FileAccess.ReadWrite);

//Save and close the PDF document
document.Save(fileStream);
document.Close(true);
