//Initialize the HTML to PDF converter.
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System.Runtime.InteropServices;

//Initialize the HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
//Initialize the blink converter settings.
BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();
if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
{
    blinkConverterSettings.CommandLineArguments.Add("--no-sandbox");
    blinkConverterSettings.CommandLineArguments.Add("--disable-setuid-sandbox");
}
// Set the conversion timeout to 5000 milliseconds 
blinkConverterSettings.ConversionTimeout = 5000;
//Assign Blink converter settings to HTML converter
htmlConverter.ConverterSettings = blinkConverterSettings;
//Convert URL to PDF
PdfDocument document = htmlConverter.Convert("https://www.google.com");
//Create file stream. 
using (FileStream fileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document 
    document.Save(fileStream);
}
//Close the document.
document.Close(true);
