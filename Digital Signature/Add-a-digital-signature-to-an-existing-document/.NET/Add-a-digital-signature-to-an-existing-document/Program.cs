// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;

//Load the PDF document.
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Gets the page.
PdfLoadedPage page = loadedDocument.Pages[0] as PdfLoadedPage;

//Creates a signature field with properties.
PdfSignatureField signatureField = new PdfSignatureField(page, "SignatureField");
signatureField.Bounds = new RectangleF(0, 0, 100, 100);
signatureField.Signature = new PdfSignature();

//Adds certificate to the signature field.
FileStream certificateStream = new FileStream(Path.GetFullPath("../../../PDF.pfx"), FileMode.Open, FileAccess.Read);
signatureField.Signature.Certificate = new PdfCertificate(certificateStream, "syncfusion");
signatureField.Signature.Reason = "I am author of this document";

//Adds the field.
loadedDocument.Form.Fields.Add(signatureField);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);