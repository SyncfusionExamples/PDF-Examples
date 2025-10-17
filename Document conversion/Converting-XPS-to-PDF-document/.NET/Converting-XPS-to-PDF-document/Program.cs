using Syncfusion.Pdf;
using Syncfusion.XPS;
using System.Reflection.Metadata;

//Initialize XPS to PDF converter.
XPSToPdfConverter converter = new XPSToPdfConverter();

//Convert the XPS to PDF document. 
using (PdfDocument document = converter.Convert(Path.GetFullPath(@"Data/Input.xps")))
{
    //Save the PDF document to file stream.
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

