// See https://aka.ms/new-console-template for more information

using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System.Runtime.InteropServices;


//Initialize the HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

//Initialize blink converter settings.
BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();
//Add cookies as name and value pair.
blinkConverterSettings.Cookies.Add("CookieName1", "CookieValue1");
blinkConverterSettings.Cookies.Add("CookieName2", "CookieValue2");

//Assign Blink converter settings to HTML converter.
htmlConverter.ConverterSettings = blinkConverterSettings;

//Convert URL to PDF document. 
PdfDocument document = htmlConverter.Convert("https://www.example.com");

//Create file stream. 
using (FileStream fileStream = new FileStream(Path.GetFullPath(@"Output/HTML-to-PDF.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document 
    document.Save(fileStream);
}
//Close the document.
document.Close(true);
