// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../SignedPDF.pdf"), FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Get the signature field from PdfLoadedDocument form field collection.
PdfLoadedSignatureField signatureField = loadedDocument.Form.Fields[0] as PdfLoadedSignatureField;
PdfSignature signature = signatureField.Signature;

//Extract the signature information.
Console.WriteLine("Digitally Signed by: " + signature.Certificate.IssuerName);
Console.WriteLine("Valid From: " + signature.Certificate.ValidFrom);
Console.WriteLine("Valid To: " + signature.Certificate.ValidTo);
Console.WriteLine("Hash Algorithm : " + signature.Settings.DigestAlgorithm);
Console.WriteLine("Cryptographics Standard : " + signature.Settings.CryptographicStandard);

//Close the document.
loadedDocument.Close(true);
