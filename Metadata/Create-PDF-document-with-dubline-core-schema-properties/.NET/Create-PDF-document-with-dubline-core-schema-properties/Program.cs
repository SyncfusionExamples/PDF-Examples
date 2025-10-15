using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Xmp;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page to the document. 
    PdfPage page = document.Pages.Add();

    //Gets XMP object.
    XmpMetadata metaData = document.DocumentInformation.XmpMetadata;

    //XMP Dublin core Schema.
    DublinCoreSchema dublin = metaData.DublinCoreSchema;

    //Set the Dublin Core Schema details of the document.
    dublin.Creator.Add("Syncfusion");
    dublin.Description.Add("Title", "Essential PDF creator");
    dublin.Title.Add("Resource name", "Documentation");
    dublin.Type.Add("PDF");
    dublin.Publisher.Add("Essential PDF");

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
