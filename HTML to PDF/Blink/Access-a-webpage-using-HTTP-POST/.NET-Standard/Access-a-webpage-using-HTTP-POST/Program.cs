// See https://aka.ms/new-console-template for more information

using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

//Initialize the HTML to PDF converter with Blink rendering engine.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter(HtmlRenderingEngine.Blink);

//Initialize blink converter settings. 
BlinkConverterSettings settings = new BlinkConverterSettings();

//Add HTTP post parameters to HttpPostFields
settings.HttpPostFields.Add("firstName", "Andrew");
settings.HttpPostFields.Add("lastName", "Fuller");

//Assign Blink converter settings to HTML converter
htmlConverter.ConverterSettings = settings;

//Convert URL to PDF
PdfDocument document = htmlConverter.Convert("https://www.example.com");

//Create file stream. 
FileStream fileStream = new FileStream(Path.GetFullPath("../../../Sample.pdf"), FileMode.CreateNew, FileAccess.ReadWrite);

//Save and close the PDF document 
document.Save(fileStream);
document.Close(true);
