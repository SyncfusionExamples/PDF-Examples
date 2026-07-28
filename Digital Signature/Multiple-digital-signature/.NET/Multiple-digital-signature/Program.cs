using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using Syncfusion.Pdf;

// Open the existing PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/SignatureFields.pdf"));

// Retrieve the first page from the PDF document.
PdfLoadedPage page = loadedDocument.Pages[0] as PdfLoadedPage;

// Access the first signature field available in the PDF form.
PdfLoadedSignatureField signatureField1 = loadedDocument.Form.Fields[0] as PdfLoadedSignatureField;

// Create a certificate object using the PFX file and its password.
PdfCertificate certificate1 = new PdfCertificate(Path.GetFullPath(@"Data/PDF.pfx"), "syncfusion");

// Digitally sign the first signature field.
signatureField1.Signature = new PdfSignature(loadedDocument, page, certificate1, "Signature1", signatureField1);

// Load the signature image for the first signer.
FileStream imageStream1 = new FileStream(Path.GetFullPath(@"Data/Student Signature.jpg"), FileMode.Open, FileAccess.Read);

PdfBitmap signatureImage = new PdfBitmap(imageStream1);


// Render the signature image within the signature field appearance.
signatureField1.Signature.Appearance.Normal.Graphics.DrawImage(signatureImage, 0, 0, signatureField1.Bounds.Width, signatureField1.Bounds.Height);

// Save the signed PDF into a memory stream.
MemoryStream stream = new MemoryStream();
loadedDocument.Save(stream);

// Close the original PDF document instance.
loadedDocument.Close(true);

// Reopen the partially signed PDF from the memory stream.
PdfLoadedDocument signedDocument = new PdfLoadedDocument(stream);

// Retrieve the first page of the signed document.
PdfLoadedPage loadedPage = signedDocument.Pages[0] as PdfLoadedPage;

// Access the second signature field in the PDF form.
PdfLoadedSignatureField signatureField2 = signedDocument.Form.Fields[1] as PdfLoadedSignatureField;

// Apply a digital signature to the second signature field.
signatureField2.Signature = new PdfSignature(signedDocument, loadedPage, certificate1, "Signature2", signatureField2);

// Load the signature image for the second signer.
FileStream imageStream2 = new FileStream(Path.GetFullPath(@"Data/Teacher Signature.png"), FileMode.Open, FileAccess.Read);

PdfBitmap signatureImage1 = new PdfBitmap(imageStream2);

// Display the signature image in the second signature field appearance.
signatureField2.Signature.Appearance.Normal.Graphics.DrawImage(signatureImage1, 0, 0, signatureField2.Bounds.Width, signatureField2.Bounds.Height);

// Save the fully signed PDF document.
signedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));

// Close the signed PDF document.
signedDocument.Close(true);
