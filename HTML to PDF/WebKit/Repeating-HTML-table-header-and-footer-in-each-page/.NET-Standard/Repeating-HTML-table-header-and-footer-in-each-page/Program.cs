// See https://aka.ms/new-console-template for more information

using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

//Initialize HTML converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

//WebKit converter settings.
WebKitConverterSettings webKitSettings = new WebKitConverterSettings();

//Enable html table header repeat on every page.
webKitSettings.EnableRepeatTableHeader = true;

//Enable html table footer repeat on every page.
webKitSettings.EnableRepeatTableFooter = true;

//Assign the WebKit settings.
htmlConverter.ConverterSettings = webKitSettings;

//Convert URL to PDF document. 
PdfDocument document = htmlConverter.Convert(Path.GetFullPath("../../../RepeatHeader.html"));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
