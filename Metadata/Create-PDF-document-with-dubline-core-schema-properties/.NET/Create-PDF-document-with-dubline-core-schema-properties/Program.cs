// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Xmp;

//Create new PDF document.
PdfDocument pdfDoc = new PdfDocument();

//Add a page to the document. 
PdfPage page = pdfDoc.Pages.Add();

//Gets XMP object.
XmpMetadata metaData = pdfDoc.DocumentInformation.XmpMetadata;

//XMP Dublin core Schema.
DublinCoreSchema dublin = metaData.DublinCoreSchema;

//Set the Dublin Core Schema details of the document.
dublin.Creator.Add("Syncfusion");
dublin.Description.Add("Title", "Essential PDF creator");
dublin.Title.Add("Resource name", "Documentation");
dublin.Type.Add("PDF");
dublin.Publisher.Add("Essential PDF");

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    pdfDoc.Save(outputFileStream);
}

//Close the document.
pdfDoc.Close(true);
