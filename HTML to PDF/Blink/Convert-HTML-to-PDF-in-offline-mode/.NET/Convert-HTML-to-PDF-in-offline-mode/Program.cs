using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

//Initialize the HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();

//Enable offline mode
blinkConverterSettings.EnableOfflineMode = true;

//Assign Blink converter settings to HTML converter
htmlConverter.ConverterSettings = blinkConverterSettings;
string inputHTML = Path.GetFullPath(@"Data/Input.html");
//Convert URL to PDF
PdfDocument document = htmlConverter.Convert(inputHTML);
//Save and close the PDF document.
document.Save(Path.GetFullPath(@"Output/Output.pdf"));
document.Close(true);