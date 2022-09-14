
// See https://aka.ms/new-console-template for more information

using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

//Initialize HTML converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

//WebKit converter settings.
WebKitConverterSettings webKitSettings = new WebKitConverterSettings();

//Enable table of contents.
webKitSettings.EnableToc = true;

//Assign the WebKit settings.
htmlConverter.ConverterSettings = webKitSettings;

//Convert HTML to PDF.
PdfDocument document = htmlConverter.Convert(Path.GetFullPath("../../../TOCSample.html"));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);