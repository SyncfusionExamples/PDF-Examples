// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Xmp;

//Create Pdf document.
PdfDocument pdfDoc = new PdfDocument();

//Create a page in document. 
PdfPage page = pdfDoc.Pages.Add();

//Get metaData object.
XmpMetadata metaData = pdfDoc.DocumentInformation.XmpMetadata;

//Create custom schema field.
CustomSchema customSchema = new CustomSchema(metaData, "custom", "http://www.syncfusion.com");
customSchema["creationDate"] = DateTime.Now.ToString();
customSchema["DOCID"] = "SYNCSAM001";
customSchema["Encryption"] = "Standard";
customSchema["Project"] = "Data processing";

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    pdfDoc.Save(outputFileStream);
}

//Close the document.
pdfDoc.Close(true);
