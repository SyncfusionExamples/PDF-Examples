// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using Syncfusion.Pdf;

//Load an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../SignatureFields.pdf"), FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Get the first page of the document.
PdfLoadedPage page = loadedDocument.Pages[0] as PdfLoadedPage;

//Get the first signature field of the PDF document.
PdfLoadedSignatureField signatureField1 = loadedDocument.Form.Fields[0] as PdfLoadedSignatureField;

//Create a certificate instance from a PFX file with a private key.
FileStream certificateStream = new FileStream(Path.GetFullPath("../../../PDF.pfx"), FileMode.Open, FileAccess.Read);
PdfCertificate certificate1 = new PdfCertificate(certificateStream, "syncfusion");

//Add a signature to the signature field.
signatureField1.Signature = new PdfSignature(loadedDocument, page, certificate1, "Signature", signatureField1);

//Set an image for the signature field.
FileStream imageStream1 = new FileStream(Path.GetFullPath("../../../Student Signature.jpg"), FileMode.Open, FileAccess.Read);
PdfBitmap signatureImage = new PdfBitmap(imageStream1);

//Insert an image in the signature appearance. 
signatureField1.Signature.Appearance.Normal.Graphics.DrawImage(signatureImage, 0, 0, 90, 20);

//Save the document into the stream.
MemoryStream stream = new MemoryStream();
loadedDocument.Save(stream);

//Load the signed PDF document.
PdfLoadedDocument signedDocument = new PdfLoadedDocument(stream);

//Load the PDF page.
PdfLoadedPage loadedPage = signedDocument.Pages[0] as PdfLoadedPage;

//Get the first signature field of the PDF document.
PdfLoadedSignatureField signatureField2 = signedDocument.Form.Fields[1] as PdfLoadedSignatureField;

//Add a signature to the signature field. 
signatureField2.Signature = new PdfSignature(signedDocument, loadedPage, certificate1, "Signature", signatureField2);

//Set an image for the signature field.
FileStream imageStream2 = new FileStream(Path.GetFullPath("../../../Teacher Signature.png"), FileMode.Open, FileAccess.Read);
PdfBitmap signatureImage1 = new PdfBitmap(imageStream2);

//Draw an image in the signature appearance. 
signatureField2.Signature.Appearance.Normal.Graphics.DrawImage(signatureImage1, 0, 0, 90, 20);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    signedDocument.Save(outputFileStream);
}

//Close the document.
signedDocument.Close(true);
loadedDocument.Close(true);