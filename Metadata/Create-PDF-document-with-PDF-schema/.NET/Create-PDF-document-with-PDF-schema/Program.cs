// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Xmp;

//Create a PDF document.
PdfDocument pdfDoc = new PdfDocument();

//Add a page.
PdfPage page = pdfDoc.Pages.Add();

//Gets XMP object.
XmpMetadata metaData = pdfDoc.DocumentInformation.XmpMetadata;

//XMP PDF Schema.
PDFSchema pdfSchema = metaData.PDFSchema;

//Set the PDF Schema details of the document.
pdfSchema.Producer = "Syncfusion";
pdfSchema.PDFVersion = "1.5";
pdfSchema.Keywords = "Essential PDF";

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    pdfDoc.Save(outputFileStream);
}

//Close the document.
pdfDoc.Close(true);