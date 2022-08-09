// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;

//Get the stream from the document.
FileStream documentStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the existing PDF document.
PdfLoadedDocument document = new PdfLoadedDocument(documentStream);

//Creates a digital signature.
PdfSignature signature = new PdfSignature(document, document.Pages[0], null, "DigitalSignature");
signature.ComputeHash += Signature_ComputeHash;

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);

void Signature_ComputeHash(object sender, PdfSignatureEventArgs ars)
{
    //Get the document bytes.
    byte[] documentBytes = ars.Data;
    SignedCms signedCms = new SignedCms(new ContentInfo(documentBytes), detached: true);

    //Compute the signature using the specified digital ID file and the password.
    X509Certificate2 certificate = new X509Certificate2("../../../PDF.pfx", "syncfusion");
    var cmsSigner = new CmsSigner(certificate);

    //Set the digest algorithm SHA256.
    cmsSigner.DigestAlgorithm = new Oid("2.16.840.1.101.3.4.2.1");
    signedCms.ComputeSignature(cmsSigner);

    //Embed the encoded digital signature to the PDF document.
    ars.SignedData = signedCms.Encode();
}