using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;

//Load the PDF document.
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Creates a digital signature.
    PdfSignature signature = new PdfSignature(loadedDocument, loadedDocument.Pages[0], null, "DigitalSignature");
    signature.ComputeHash += Signature_ComputeHash;
    //Save the PDF document 
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

void Signature_ComputeHash(object sender, PdfSignatureEventArgs ars)
{
    //Get the document bytes.
    byte[] documentBytes = ars.Data;
    SignedCms signedCms = new SignedCms(new ContentInfo(documentBytes), detached: true);
    //Compute the signature using the specified digital ID file and the password.
    X509Certificate2 certificate = new X509Certificate2(Path.GetFullPath(@"Data/PDF.pfx"), "syncfusion");
    CmsSigner cmsSigner = new CmsSigner(certificate);
    //Set the digest algorithm SHA256.
    cmsSigner.DigestAlgorithm = new Oid("2.16.840.1.101.3.4.2.1");
    signedCms.ComputeSignature(cmsSigner);
    //Embed the encoded digital signature to the PDF document.
    ars.SignedData = signedCms.Encode();
}