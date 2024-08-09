// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using System.Security.Cryptography.X509Certificates;

//Gets the stream from the document
FileStream documentStream = new FileStream(@"Data/DigitalSignature.pdf", FileMode.Open, FileAccess.Read);
//Load an existing signed PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(documentStream);

//Get signature field.
PdfLoadedSignatureField loadedSignatureField = loadedDocument.Form.Fields[0] as PdfLoadedSignatureField;
//X509Certificate2Collection to check the signer's identity using root certificates.
X509CertificateCollection collection = new X509CertificateCollection();
//Create new X509Certificate2 with the root certificate.
X509Certificate2 certificate = new X509Certificate2(@"Data/Root.cer");
//Add the certificate to the collection.
collection.Add(certificate);
//Create new X509Certificate2 with the intermediate certificate.
certificate = new X509Certificate2(@"Data/Intermediate0.cer");
//Add the certificate to the collection.
collection.Add(certificate);
//Validate signature and get the validation result
PdfSignatureValidationResult result = loadedSignatureField.ValidateSignature(collection);

foreach (PdfSignerCertificate signerCertificate in result.SignerCertificates)
{
    if (signerCertificate.OcspCertificate != null)
    {
        foreach (X509Certificate2 item in signerCertificate.OcspCertificate.Certificates)
        {
            string subjectName = "The OCSP Response was signed by " + item.SubjectName.Name;
        }
        bool isEmbbed = signerCertificate.OcspCertificate.IsEmbedded;
        DateTime validForm = signerCertificate.OcspCertificate.ValidFrom;
        DateTime validTo = signerCertificate.OcspCertificate.ValidTo;
    }
    if (signerCertificate.CrlCertificate != null)
    {
        foreach (X509Certificate2 item in signerCertificate.CrlCertificate.Certificates)
        {
            string subjectName = "The CRL was signed by " + item.SubjectName.Name;
        }
        bool isEmbbed = signerCertificate.CrlCertificate.IsEmbedded;
        DateTime validForm = signerCertificate.CrlCertificate.ValidFrom;
        DateTime validTo = signerCertificate.CrlCertificate.ValidTo;
    }
}

//Close the document
loadedDocument.Close(true);
