// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;

//Create PDF document.
PdfDocument pdfDoc = new PdfDocument();

//Add new PDF page.
PdfPage page = pdfDoc.Pages.Add();

//Add Custom MetaData.
pdfDoc.DocumentInformation.CustomMetadata["ID"] = "IO1";
pdfDoc.DocumentInformation.CustomMetadata["CompanyName"] = "Syncfusion";
pdfDoc.DocumentInformation.CustomMetadata["Key"] = "DocumentKey";

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    pdfDoc.Save(outputFileStream);
}

//Close the document.
pdfDoc.Close(true);

