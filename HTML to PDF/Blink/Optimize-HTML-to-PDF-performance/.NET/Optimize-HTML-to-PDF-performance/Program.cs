// See https://aka.ms/new-console-template for more information

using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System.IO;
using System.Runtime.InteropServices;

//Initialize the HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
//Reuse the browser instance.           
htmlConverter.ReuseBrowserProcess = true;

//Create PDF document. 
PdfDocument document = new PdfDocument();
//Create memory stream.
MemoryStream memoryStream = new MemoryStream();

for (int i = 0; i < 10; i++)
{
    //Initialize the blink converter settings. 
    BlinkConverterSettings settings = new BlinkConverterSettings();
    settings.AdditionalDelay = 1000;
    settings.EnableJavaScript = true;
    //Assign the settings to HTML converter.
    htmlConverter.ConverterSettings = settings;
    
    //Convert the URL to PDF document.
    document = htmlConverter.Convert("https://www.google.com");

    //Save and close the PDF document.
    document.Save(memoryStream);
    document.Close(true);
    File.WriteAllBytes(Path.GetFullPath(@"Output/") + Guid.NewGuid().ToString() + ".pdf", memoryStream.ToArray());
}

//Close HTML converter.
htmlConverter.Close();
