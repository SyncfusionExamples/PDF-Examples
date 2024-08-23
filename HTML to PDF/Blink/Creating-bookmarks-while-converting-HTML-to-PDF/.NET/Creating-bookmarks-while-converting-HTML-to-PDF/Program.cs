// See https://aka.ms/new-console-template for more information

using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System.Runtime.InteropServices;

//Initialize the HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

//Initialize blink converter settings. 
BlinkConverterSettings settings = new BlinkConverterSettings();
if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
{
    settings.CommandLineArguments.Add("--no-sandbox");
    settings.CommandLineArguments.Add("--disable-setuid-sandbox");
}
//Set enable bookmarks.
settings.EnableBookmarks = true;

//Assign Blink converter settings to HTML converter.
htmlConverter.ConverterSettings = settings;

//Convert HTML to PDF document. 
PdfDocument document = htmlConverter.Convert(Path.GetFullPath(@"Data/Input.html"));

//Create file stream. 
FileStream fileStream = new FileStream(Path.GetFullPath(@"Output/HTML-to-PDF.pdf"), FileMode.CreateNew, FileAccess.ReadWrite);

//Save and close the PDF document.
document.Save(fileStream);
document.Close(true);
