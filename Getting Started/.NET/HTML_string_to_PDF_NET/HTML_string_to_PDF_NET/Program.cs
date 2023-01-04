
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System.IO;

string path = Path.GetFullPath(@"../../../Autumn Leaves.jpg");
//Initialize HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
//HTML string and Base URL.
string htmlText = "<html><body><img src=\"" + path + "\" alt=\"Syncfusion_logo\" width=\"200\" height=\"70\"><p> Hello World</p></body></html>";
string baseUrl = @"C:/Temp/HTMLFiles/";
//Convert URL to PDF.
PdfDocument document = htmlConverter.Convert(htmlText, baseUrl);
//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}
//Close the document.
document.Close(true);