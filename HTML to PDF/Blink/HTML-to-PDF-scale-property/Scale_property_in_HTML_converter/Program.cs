
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

//Initialize the HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
//Initialize blink converter settings.
BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();
//Set the Scale.
blinkConverterSettings.Scale = 1.0f;
//Assign Blink converter settings to HTML converter.
htmlConverter.ConverterSettings = blinkConverterSettings;
//Convert URL to PDF document. 
PdfDocument document = htmlConverter.Convert("https://www.syncfusion.com");
//Create a file stream.
FileStream fileStream = new FileStream("HTMLtoPDF.pdf", FileMode.Create, FileAccess.ReadWrite);
//Save a PDF document to a file stream.
document.Save(fileStream);
//Close the document.
document.Close(true);
