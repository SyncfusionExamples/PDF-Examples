// See https://aka.ms/new-console-template for more information

using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

//Initialize the HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

//Initialize blink converter settings. 
BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();

//Disable JavaScript; By default, true.
blinkConverterSettings.EnableJavaScript = false;

//Assign Blink converter settings to HTML converter.
htmlConverter.ConverterSettings = blinkConverterSettings;

//Convert URL to PDF document.  
PdfDocument document = htmlConverter.Convert("https://www.google.com");

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../HTML-to-PDF.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
