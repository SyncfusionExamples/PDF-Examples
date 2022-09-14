// See https://aka.ms/new-console-template for more information

using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

//Initialize HTML converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

//Convert Partial webpage to PDF document. 
PdfDocument document = htmlConverter.ConvertPartialHtml(Path.GetFullPath("../../../HtmlSample.html"), "pic");

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);