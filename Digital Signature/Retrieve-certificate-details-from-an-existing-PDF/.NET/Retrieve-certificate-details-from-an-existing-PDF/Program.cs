using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;

//Load the PDF document.
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the signature field.
    PdfLoadedSignatureField signatureField = loadedDocument.Form.Fields[0] as PdfLoadedSignatureField;
    //Get the certificate.
    PdfCertificate certificate = signatureField.Signature.Certificate;
    //Get the signed date.
    DateTime date = signatureField.Signature.SignedDate;
    //Get the signed name.
    string name = signatureField.Signature.SignedName;
    //Gets the certificate subject's name.
    string subjectName = certificate.SubjectName;
    //Gets the certificate issuer's name.
    string issuerName = certificate.IssuerName;
    //Get certificate validation date information.
    DateTime validFrom = certificate.ValidFrom;
    DateTime validTo = certificate.ValidTo;
    //Write the digital signature details in console window. 
    Console.WriteLine("Signed Name: " + name);
    Console.WriteLine("Certificate subject name: " + subjectName);
    Console.WriteLine("Certificate issuer's name: " + issuerName);
    Console.WriteLine("Certificate validation from: " + validFrom);
    Console.WriteLine("Certificate valid to:" + validTo);
}