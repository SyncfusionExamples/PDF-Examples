using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Xmp;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page.
    PdfPage page = document.Pages.Add();

    //Gets XMP object.
    XmpMetadata metaData = document.DocumentInformation.XmpMetadata;

    //XMP Rights Management Schema.
    BasicJobTicketSchema basicJob = metaData.BasicJobTicketSchema;

    //Set the Rights Management Schema details of the document.
    basicJob.JobRef.Add("PDF document creation");

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
