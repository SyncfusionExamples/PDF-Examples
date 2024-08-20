// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.XPS;
using System.Reflection.Metadata;

//Initialize XPS to PDF converter.
XPSToPdfConverter converter = new XPSToPdfConverter();

//Open the XPS file as stream.
FileStream fileStream = new FileStream(System.IO.Path.GetFullPath(@"Data/Input.xps"), FileMode.Open, FileAccess.ReadWrite);

//Convert the XPS to PDF document. 
PdfDocument document = converter.Convert(fileStream);

//Create file stream.
using (FileStream outputFileStream = new FileStream(System.IO.Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);

