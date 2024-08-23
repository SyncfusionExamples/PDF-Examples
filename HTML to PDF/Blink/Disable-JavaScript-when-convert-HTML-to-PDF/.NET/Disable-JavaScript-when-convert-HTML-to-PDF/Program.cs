// See https://aka.ms/new-console-template for more information

using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System.Runtime.InteropServices;

//Initialize the HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

//Initialize blink converter settings. 
BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();
if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
{
    //Set command line arugument to run without the sandbox.
    blinkConverterSettings.CommandLineArguments.Add("--no-sandbox");
    blinkConverterSettings.CommandLineArguments.Add("--disable-setuid-sandbox");
}
//Disable JavaScript; By default, true.
blinkConverterSettings.EnableJavaScript = false;

//Assign Blink converter settings to HTML converter.
htmlConverter.ConverterSettings = blinkConverterSettings;

//Convert URL to PDF document.  
PdfDocument document = htmlConverter.Convert("https://www.google.com");

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/HTML-to-PDF.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
