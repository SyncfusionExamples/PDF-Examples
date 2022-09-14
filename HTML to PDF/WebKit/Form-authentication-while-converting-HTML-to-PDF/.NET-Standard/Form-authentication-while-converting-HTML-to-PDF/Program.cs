// See https://aka.ms/new-console-template for more information

using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

//Initialize HTML converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

//WebKit converter settings.
WebKitConverterSettings webKitSettings = new WebKitConverterSettings();

//Add cookies as name and value pair.
webKitSettings.Cookies.Add("CookieName1", " CookieValue1");
webKitSettings.Cookies.Add("CookieName2", " CookieValue2");

//Assign the WebKit settings.
htmlConverter.ConverterSettings = webKitSettings;

//Convert URL to PDF document. 
PdfDocument document = htmlConverter.Convert("https://www.google.com");

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
