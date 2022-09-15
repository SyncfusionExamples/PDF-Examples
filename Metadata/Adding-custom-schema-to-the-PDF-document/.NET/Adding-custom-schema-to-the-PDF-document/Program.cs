// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Xmp;

//Create PDF document.
PdfDocument pdfDoc = new PdfDocument();

//Add a page to the document. 
PdfPage page = pdfDoc.Pages.Add();

//Create XML Document container.
XmpMetadata metaData = new XmpMetadata(pdfDoc.DocumentInformation.XmpMetadata.XmlData);

//Create custom schema.
CustomSchema customSchema = new CustomSchema(metaData, "custom", "http://www.syncfusion.com");
customSchema["Author"] = "Syncfusion";
customSchema["creationDate"] = DateTime.Now.ToString();
customSchema["DOCID"] = "SYNCSAM001";

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    pdfDoc.Save(outputFileStream);
}

//Close the document.
pdfDoc.Close(true);


