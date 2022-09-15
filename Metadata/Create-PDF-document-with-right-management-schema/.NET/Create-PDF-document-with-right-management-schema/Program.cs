// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Xmp;

//Create PDF document.
PdfDocument pdfDoc = new PdfDocument();

//Add a page to the document. 
PdfPage page = pdfDoc.Pages.Add();

//Gets XMP object.
XmpMetadata metaData = pdfDoc.DocumentInformation.XmpMetadata;

//XMP Rights Management Schema.
RightsManagementSchema rights = metaData.RightsManagementSchema;

//Set the Rights Management Schema details of the document.
rights.Certificate = new Uri("http://syncfusion.com");
rights.Owner.Add("Syncfusion");
rights.Marked = true;

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    pdfDoc.Save(outputFileStream);
}

//Close the document.
pdfDoc.Close(true);
