// See https://aka.ms/new-console-template for more information

using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

//Initialize HTML converter with WebKit rendering engine.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

//Convert Webkit Converter settings. 
WebKitConverterSettings webKitSettings = new WebKitConverterSettings();

//////Enable offline mode.
////webKitSettings.EnableOfflineMode = true;

//Assign WebKit settings to HTML converter.
htmlConverter.ConverterSettings = webKitSettings;

//Convert HTML to PDF document. 
PdfDocument document = htmlConverter.Convert(Path.GetFullPath("../../../HtmlSample.html"));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
