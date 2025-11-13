using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using System.Security.Cryptography.X509Certificates;

//Load the PDF document.
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //X509Certificate2Collection to check the signer's identity using root certificates.
    X509Certificate2Collection collection = new X509Certificate2Collection();
    //Creates a certificate instance from PFX file with private key.
    FileStream certificateStream = new FileStream(Path.GetFullPath(@"Data/PDF.pfx"), FileMode.Open, FileAccess.Read);
    byte[] data = new byte[certificateStream.Length];
    certificateStream.Read(data, 0, data.Length);
    //Create new X509Certificate2 with the root certificate.
    X509Certificate2 certificate = new X509Certificate2(data, "syncfusion");
    //Add the certificate to the collection.
    collection.Add(certificate);
    //Validate all signatures in loaded PDF document and get the list of validation result.
    List<PdfSignatureValidationResult> results;
    bool isValid = loadedDocument.Form.Fields.ValidateSignatures(collection, out results);
    Console.WriteLine("All signatures in the document are valid: " + isValid);
}