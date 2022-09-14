// See https://aka.ms/new-console-template for more information


using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

//Initialize HTML converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

string url = "https://asp.syncfusion.com/demos/web/pdf/helloworld.aspx";

//Initialize new instance of URI. 
Uri getMethodUri = new Uri(url);

string httpGetData = getMethodUri.Query.Length > 0 ? "&" : "?" + String.Format("{0}={1}", "firstName", "Andrew");
httpGetData += String.Format("&{0}={1}", "lastName", "Fuller");
string urlToConvert = url + httpGetData;

//Convert HTML to PDF document. 
PdfDocument document = htmlConverter.Convert(urlToConvert);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
