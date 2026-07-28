using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

//Open the signed PDF document.
using PdfLoadedDocument ldoc = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf"));
//Retrieve the signature field from the document form.
PdfLoadedSignatureField lSigFld = ldoc.Form.Fields[0] as PdfLoadedSignatureField;
//Create a collection to store the root and intermediate certificates.
X509CertificateCollection collection = new X509CertificateCollection();
string[] certificates =
{
    "Root.cer",
    "Intermediate0.cer",
    "Intermediate1.cer"
};
//Load certificates and add them to the certificate collection.
foreach (string certFile in certificates)
{
    collection.Add(new X509Certificate2(File.ReadAllBytes(Path.GetFullPath(@"Data/" + certFile))));
}
//Verify the digital signature using the certificate chain.
PdfSignatureValidationResult result = lSigFld.ValidateSignature(collection);
StringBuilder builder = new StringBuilder();
builder.AppendLine("Signature is " + result.SignatureStatus);
builder.AppendLine();
builder.AppendLine("----------Validation Summary----------");
builder.AppendLine();
//Check whether the signed document has been modified.
if (result.IsDocumentModified)
{
    builder.AppendLine("The document has been altered or corrupted since the signature was applied.");
}
else
{
    builder.AppendLine("The document has not been modified since the signature was applied.");
}
//Add signer certificate information to the report.
builder.AppendLine("Digitally signed by: " + lSigFld.Signature.Certificate.IssuerName);
builder.AppendLine("Valid From: " + lSigFld.Signature.Certificate.ValidFrom);
builder.AppendLine("Valid To: " + lSigFld.Signature.Certificate.ValidTo);
builder.AppendLine("Signature Algorithm: " + result.SignatureAlgorithm);
builder.AppendLine("Hash Algorithm: " + result.DigestAlgorithm);
//Include revocation status details.
builder.AppendLine("OCSP Revocation Status: " + result.RevocationResult.OcspRevocationStatus);
if (result.RevocationResult.OcspRevocationStatus == RevocationStatus.None && result.RevocationResult.IsRevokedCRL)
{
    builder.AppendLine("CRL is revoked.");
}
builder.AppendLine();
builder.AppendLine("--------Revocation Information---------");
builder.AppendLine();
//Extract OCSP and CRL validation details for each signer certificate.
foreach (PdfSignerCertificate signerCertificate in result.SignerCertificates)
{
    if (signerCertificate.OcspCertificate != null)
    {
        builder.AppendLine("------------OCSP Certificate-------------");
        foreach (X509Certificate2 item in signerCertificate.OcspCertificate.Certificates)
        {
            builder.AppendLine("The OCSP Response was signed by: " + item.SubjectName.Name);
        }
        builder.AppendLine("Is Embedded: " + signerCertificate.OcspCertificate.IsEmbedded);
        builder.AppendLine("Valid From: " + signerCertificate.OcspCertificate.ValidFrom);
        builder.AppendLine("Valid To: " + signerCertificate.OcspCertificate.ValidTo);
        builder.AppendLine();
    }

    if (signerCertificate.CrlCertificate != null)
    {
        builder.AppendLine("------------CRL Certificate--------------");
        foreach (X509Certificate2 item in signerCertificate.CrlCertificate.Certificates)
        {
            builder.AppendLine("The CRL was signed by: " + item.SubjectName.Name);
        }
        builder.AppendLine("Is Embedded: " + signerCertificate.CrlCertificate.IsEmbedded);
        builder.AppendLine("Valid From: " + signerCertificate.CrlCertificate.ValidFrom);
        builder.AppendLine("Valid To: " + signerCertificate.CrlCertificate.ValidTo);
        builder.AppendLine();
    }
}
//Write the validation report to a text file.
File.WriteAllText(Path.GetFullPath(@"Output/Output.txt"), builder.ToString());