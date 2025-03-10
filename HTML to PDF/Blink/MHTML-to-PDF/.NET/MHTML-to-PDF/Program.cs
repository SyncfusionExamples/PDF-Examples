using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

// Initialize HTML to PDF converter
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

// Convert the MHTML content (as a string) to PDF
PdfDocument document = htmlConverter.Convert(Path.GetFullPath(@"Data/Input.mhtml"));

// Save the PDF document to a file
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    document.Save(outputFileStream);
}
// Close the PDF document
document.Close(true);
