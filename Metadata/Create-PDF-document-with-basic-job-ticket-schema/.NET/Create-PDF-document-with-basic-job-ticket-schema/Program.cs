// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Xmp;

//Create a document.
PdfDocument pdfDoc = new PdfDocument();

//Add a page.
PdfPage page = pdfDoc.Pages.Add();

//Gets XMP object.
XmpMetadata metaData = pdfDoc.DocumentInformation.XmpMetadata;

//XMP Rights Management Schema.
BasicJobTicketSchema basicJob = metaData.BasicJobTicketSchema;

//Set the Rights Management Schema details of the document.
basicJob.JobRef.Add("PDF document creation");

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    pdfDoc.Save(outputFileStream);
}

//Close the document.
pdfDoc.Close(true);
