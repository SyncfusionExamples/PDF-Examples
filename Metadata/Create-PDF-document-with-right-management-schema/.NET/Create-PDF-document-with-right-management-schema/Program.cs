using Syncfusion.Pdf;
using Syncfusion.Pdf.Xmp;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page to the document. 
    PdfPage page = document.Pages.Add();

    //Gets XMP object.
    XmpMetadata metaData = document.DocumentInformation.XmpMetadata;

    //XMP Rights Management Schema.
    RightsManagementSchema rights = metaData.RightsManagementSchema;

    //Set the Rights Management Schema details of the document.
    rights.Certificate = new Uri("http://syncfusion.com");
    rights.Owner.Add("Syncfusion");
    rights.Marked = true;

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
