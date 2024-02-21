//Initialize the HTML to PDF converter.
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

//Initialize the HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
//Initialize the blink converter settings.
BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();
// Set the conversion timeout to 5000 milliseconds 
blinkConverterSettings.ConversionTimeout = 5000;
//Assign Blink converter settings to HTML converter
htmlConverter.ConverterSettings = blinkConverterSettings;
//Convert URL to PDF
PdfDocument document = htmlConverter.Convert("https://www.google.com");
//Create a file stream.
FileStream fileStream = new FileStream("HTML-to-PDF.pdf", FileMode.CreateNew, FileAccess.ReadWrite);
//Save and close the PDF document.
document.Save(fileStream);
//Close the document.
document.Close(true);
