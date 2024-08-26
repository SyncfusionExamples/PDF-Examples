using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System.Runtime.InteropServices;

//Initialize HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
//Initialize the BlinkConverterSettings.
BlinkConverterSettings settings = new BlinkConverterSettings();
if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
{
    //Set command line arugument to run without the sandbox.
    settings.CommandLineArguments.Add("--no-sandbox");
    settings.CommandLineArguments.Add("--disable-setuid-sandbox");
}
//Set true to enable the accessibility tags in PDF generation.
settings.EnableAccessibilityTags = true;
//Assign the BlinkConverterSettings to the ConverterSettings property of HtmlToPdfConverter.
htmlConverter.ConverterSettings = settings;
//Convert URL to PDF.
PdfDocument document = htmlConverter.Convert("file:///D:/PDF-Examples/HTML%20to%20PDF/Blink/Accessible_PDF_In_HTML_to_PDF/.NET/Accessible%20PDF/Data/Input.html");
//Save and close the PDF document.
FileStream fileStream = new FileStream(Path.GetFullPath(@"Output/HTML-to-PDF.pdf"), FileMode.Create, FileAccess.ReadWrite);
//Save and close the PDF document 
document.Save(fileStream);
document.Close(true);
