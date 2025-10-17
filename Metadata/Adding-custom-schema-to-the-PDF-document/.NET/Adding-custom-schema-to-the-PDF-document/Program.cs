using Syncfusion.Pdf;
using Syncfusion.Pdf.Xmp;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page to the document. 
    PdfPage page = document.Pages.Add();

    //Create XML Document container.
    XmpMetadata metaData = new XmpMetadata(document.DocumentInformation.XmpMetadata.XmlData);

    //Create custom schema.
    CustomSchema customSchema = new CustomSchema(metaData, "custom", "http://www.syncfusion.com");
    customSchema["Author"] = "Syncfusion";
    customSchema["creationDate"] = DateTime.Now.ToString();
    customSchema["DOCID"] = "SYNCSAM001";

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}


