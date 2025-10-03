using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

//Initialize the HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();
//Set the Blink viewport size.
blinkConverterSettings.ViewPortSize = new Size(1280, 0);
blinkConverterSettings.Margin.All = 30;
//Set the custom CSS
blinkConverterSettings.Css = "body {\r\n background-color: lightyellow; \r\n}";
htmlConverter.ConverterSettings = blinkConverterSettings;
//Convert the URL to PDF document.
PdfDocument document = htmlConverter.Convert("https://www.google.com");

//Save the PDF document 
document.Save(Path.GetFullPath(@"Output/Output.pdf"));
//Close the document.
document.Close(true);