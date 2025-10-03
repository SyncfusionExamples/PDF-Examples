using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

//Initialize HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
//Initialize the BlinkConverterSettings.
BlinkConverterSettings settings = new BlinkConverterSettings();
//Set true to enable the accessibility tags in PDF generation.
settings.EnableAccessibilityTags = true;
//Assign the BlinkConverterSettings to the ConverterSettings property of HtmlToPdfConverter.
htmlConverter.ConverterSettings = settings;
//Convert URL to PDF.
PdfDocument document = htmlConverter.Convert("file:///D:/PDF-Examples/HTML%20to%20PDF/Blink/Accessible_PDF_In_HTML_to_PDF/.NET/Accessible%20PDF/Data/Input.html");

//Save the PDF document 
document.Save(Path.GetFullPath(@"Output/Output.pdf"));
//Close the document.
document.Close(true);
