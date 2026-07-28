using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using Syncfusion.Pdf;

//Load an existing PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/SignatureFields.pdf"));
//Get the first page of the document.
PdfLoadedPage page = loadedDocument.Pages[0] as PdfLoadedPage;
//Get the first signature field of the PDF document.
PdfLoadedSignatureField signatureField1 = loadedDocument.Form.Fields[0] as PdfLoadedSignatureField;
//Create a certificate instance from a PFX file with a private key.
PdfCertificate certificate1 = new PdfCertificate(Path.GetFullPath(@"Data/PDF.pfx"), "syncfusion");
//Add a signature to the signature field.
signatureField1.Signature = new PdfSignature(loadedDocument, page, certificate1, "Signature", signatureField1);
//Set an image for the signature field.
FileStream imageStream1 = new FileStream(Path.GetFullPath(@"Data/Student Signature.jpg"), FileMode.Open, FileAccess.Read);
PdfBitmap signatureImage = new PdfBitmap(imageStream1);
imageStream1.Position = 0;
//Insert an image in the signature appearance. 
signatureField1.Signature.Appearance.Normal.Graphics.DrawImage(signatureImage, 0, 0, signatureField1.Bounds.Width, signatureField1.Bounds.Height);
//Save the document into the stream.
MemoryStream stream = new MemoryStream();
loadedDocument.Save(stream);
//Close the PDF document
loadedDocument.Close(true);
stream.Position = 0;
//Load the signed PDF document.
PdfLoadedDocument signedDocument = new PdfLoadedDocument(stream);
//Load the PDF page.
PdfLoadedPage loadedPage = signedDocument.Pages[0] as PdfLoadedPage;
//Get the first signature field of the PDF document.
PdfLoadedSignatureField signatureField2 = signedDocument.Form.Fields[1] as PdfLoadedSignatureField;
//Add a signature to the signature field. 
signatureField2.Signature = new PdfSignature(signedDocument, loadedPage, certificate1, "Signature", signatureField2);
//Set an image for the signature field.
FileStream imageStream2 = new FileStream(Path.GetFullPath(@"Data/Teacher Signature.png"), FileMode.Open, FileAccess.Read);
PdfBitmap signatureImage1 = new PdfBitmap(imageStream2);
imageStream2.Position = 0;
//Draw an image in the signature appearance. 
signatureField2.Signature.Appearance.Normal.Graphics.DrawImage(signatureImage1, 0, 0, signatureField2.Bounds.Width, signatureField2.Bounds.Height);
//Save the PDF document
signedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
//Close the PDF document
signedDocument.Close(true);