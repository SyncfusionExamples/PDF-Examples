using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

//Initialize the HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

//Create blink converter settings.
BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();

//Set username and password. 
blinkConverterSettings.Username = "username";
blinkConverterSettings.Password = "password";

//Assign Blink converter settings to HTML converter.
htmlConverter.ConverterSettings = blinkConverterSettings;

//Convert URL to PDF document. 
PdfDocument document = htmlConverter.Convert("https://www.example.com");

//Save the PDF document 
document.Save(Path.GetFullPath(@"Output/Output.pdf"));
//Close the document.
document.Close(true);
