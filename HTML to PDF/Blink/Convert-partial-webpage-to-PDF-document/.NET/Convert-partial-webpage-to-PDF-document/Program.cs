// See https://aka.ms/new-console-template for more information

using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

//Initialize the HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

//Convert Partial webpage to PDF document. 
PdfDocument document = htmlConverter.ConvertPartialHtml(Path.GetFullPath("../../../input.html"), "picture");

//Create file stream. 
FileStream fileStream = new FileStream(Path.GetFullPath("../../../Sample.pdf"), FileMode.CreateNew, FileAccess.ReadWrite);

//Save and close the PDF document 
document.Save(fileStream);
document.Close(true);