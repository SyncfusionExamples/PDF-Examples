// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a new page to PDF document.
PdfPage page = document.Pages.Add();

//Create PDF Signature field.
PdfSignatureField signatureField = new PdfSignatureField(page, "Signature");

//Set properties to the signature field.
signatureField.Bounds = new Syncfusion.Drawing.RectangleF(50, 50, 90, 20);
signatureField.ToolTip = "Signature";

//Add the form field to the document.
document.Form.Fields.Add(signatureField);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
