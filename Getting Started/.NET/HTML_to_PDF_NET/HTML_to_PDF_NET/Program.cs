using Syncfusion.Pdf;
using Syncfusion.HtmlConverter;

//Initialize HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
//Convert URL to PDF document. 
PdfDocument document = htmlConverter.Convert("https://www.google.com");

//Save the PDF document
document.Save(Path.GetFullPath(@"Output/Output.pdf"));
//Close the document.
document.Close(true);