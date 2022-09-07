// See https://aka.ms/new-console-template for more information

using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

//Initialize HTML converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

//WebKit converter settings.
WebKitConverterSettings webKitSettings = new WebKitConverterSettings();

//Add post parameters.
webKitSettings.HttpPostFields.Add("firstName", "Andrew");
webKitSettings.HttpPostFields.Add("lastName", "Fuller");

//Assign the WebKit settings.
htmlConverter.ConverterSettings = webKitSettings;

//Convert HTML to PDF document. 
PdfDocument document = htmlConverter.Convert("https://asp.syncfusion.com/demos/web/pdf/helloworld.aspx");

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);