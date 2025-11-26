using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

//Initialize HTML to PDF converter
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
//Convert URL to PDF
using (PdfDocument document = htmlConverter.Convert("https://www.google.com"))
{
    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}