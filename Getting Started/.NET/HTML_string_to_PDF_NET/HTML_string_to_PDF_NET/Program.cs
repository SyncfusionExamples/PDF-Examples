using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System.IO;

string path = Path.GetFullPath(@"Data/Autumn Leaves.jpg");
//Initialize HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
//HTML string and Base URL.
string htmlText = "<html><body><img src=\"" + path + "\" alt=\"Syncfusion_logo\" width=\"200\" height=\"70\"><p> Hello World</p></body></html>";
string baseUrl = @"C:/Temp/HTMLFiles/";
//Convert URL to PDF.
PdfDocument document = htmlConverter.Convert(htmlText, baseUrl);

//Save the PDF document
document.Save(Path.GetFullPath(@"Output/Output.pdf"));
//Close the document.
document.Close(true);