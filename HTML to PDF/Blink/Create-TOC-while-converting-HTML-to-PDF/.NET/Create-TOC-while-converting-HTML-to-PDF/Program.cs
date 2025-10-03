// See https://aka.ms/new-console-template for more information

using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

//Initialize the HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

//Initialize blink converter settings. 
BlinkConverterSettings settings = new BlinkConverterSettings();

//Set enable table of contents.
settings.EnableToc = true;

//Assign Blink converter settings to HTML converter.
htmlConverter.ConverterSettings = settings;

//Convert HTML to PDF document. 
PdfDocument document = htmlConverter.Convert(Path.GetFullPath(@"Data/Input.html"));

//Save the PDF document 
document.Save(Path.GetFullPath(@"Output/Output.pdf"));
//Close the document.
document.Close(true);
