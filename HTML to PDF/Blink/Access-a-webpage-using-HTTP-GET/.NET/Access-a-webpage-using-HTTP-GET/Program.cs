// See https://aka.ms/new-console-template for more information

using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System.Runtime.InteropServices;

//Initialize the HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

//Set the URL. 
string url = "https://www.example.com";
Uri getMethodUri = new Uri(url);

//Passed the parameter in string. 
string httpGetData = getMethodUri.Query.Length > 0 ? "&" : "?" + String.Format("{0}={1}", "firstName", "Andrew");
httpGetData += String.Format("&{0}={1}", "lastName", "Fuller");
string urlToConvert = url + httpGetData;

//Convert URL to PDF document. 
PdfDocument document = htmlConverter.Convert(urlToConvert);

//Create file stream. 
using (FileStream fileStream = new FileStream(Path.GetFullPath(@"Output/HTML-to-PDF.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document 
    document.Save(fileStream);
}
//Close the document.
document.Close(true);
