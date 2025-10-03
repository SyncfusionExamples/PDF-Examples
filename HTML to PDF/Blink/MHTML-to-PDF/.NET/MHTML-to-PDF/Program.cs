using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

// Initialize HTML to PDF converter
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

// Convert the MHTML content (as a string) to PDF
PdfDocument document = htmlConverter.Convert(Path.GetFullPath(@"Data/Input.mhtml"));

//Save the PDF document
document.Save(Path.GetFullPath(@"Output/Output.pdf"));
// Close the PDF document
document.Close(true);
