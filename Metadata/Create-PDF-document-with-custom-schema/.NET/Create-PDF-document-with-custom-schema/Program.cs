using Syncfusion.Pdf;
using Syncfusion.Pdf.Xmp;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Create a page in document. 
    PdfPage page = document.Pages.Add();

    //Get metaData object.
    XmpMetadata metaData = document.DocumentInformation.XmpMetadata;

    //Create custom schema field.
    CustomSchema customSchema = new CustomSchema(metaData, "custom", "http://www.syncfusion.com");
    customSchema["creationDate"] = DateTime.Now.ToString();
    customSchema["DOCID"] = "SYNCSAM001";
    customSchema["Encryption"] = "Standard";
    customSchema["Project"] = "Data processing";

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
