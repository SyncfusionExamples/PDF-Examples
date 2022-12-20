// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

//Initialize the HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

//Create blink converter settings. 
BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();

//Set Blink viewport size.
blinkConverterSettings.ViewPortSize = new Size(800, 0);

//Assign Blink converter settings to HTML converter.
htmlConverter.ConverterSettings = blinkConverterSettings;

//Convert URL to PDF document. 
PdfDocument document = htmlConverter.Convert("https://www.google.com");

//Create file stream. 
FileStream fileStream = new FileStream(Path.GetFullPath("../../../HTML-to-PDF.pdf"), FileMode.CreateNew, FileAccess.ReadWrite);

//Save and close the PDF document.
document.Save(fileStream);
document.Close(true);
