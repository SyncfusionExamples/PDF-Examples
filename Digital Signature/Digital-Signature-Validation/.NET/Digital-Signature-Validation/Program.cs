using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

string dataPath = Path.GetFullPath(@"Data/");

// Load signed PDF document
using PdfLoadedDocument ldoc = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf"));

// Get signature field
PdfLoadedSignatureField lSigFld = ldoc.Form.Fields[0] as PdfLoadedSignatureField;

// Root and Intermediate Certificates
X509CertificateCollection collection = new X509CertificateCollection();

string[] certificates =
{
    "Root.cer",
    "Intermediate0.cer",
    "Intermediate1.cer"
};

foreach (string certFile in certificates)
{
    byte[] certData = File.ReadAllBytes(Path.Combine(dataPath, certFile));

    X509Certificate2 certificate = new X509Certificate2(certData);

    collection.Add(certificate);
}

// Validate signature
PdfSignatureValidationResult result = lSigFld.ValidateSignature(collection);

StringBuilder builder = new StringBuilder();

builder.AppendLine("Signature is " + result.SignatureStatus);
builder.AppendLine();
builder.AppendLine("----------Validation Summary----------");
builder.AppendLine();

// Modified check
if (result.IsDocumentModified)
{
    builder.AppendLine("The document has been altered or corrupted since the signature was applied.");
}
else
{
    builder.AppendLine("The document has not been modified since the signature was applied.");
}

// Certificate details
builder.AppendLine("Digitally signed by: " + lSigFld.Signature.Certificate.IssuerName);

builder.AppendLine("Valid From: " + lSigFld.Signature.Certificate.ValidFrom);

builder.AppendLine("Valid To: " + lSigFld.Signature.Certificate.ValidTo);

builder.AppendLine("Signature Algorithm: " + result.SignatureAlgorithm);

builder.AppendLine("Hash Algorithm: " + result.DigestAlgorithm);

// Revocation details
builder.AppendLine("OCSP Revocation Status: " + result.RevocationResult.OcspRevocationStatus);

if (result.RevocationResult.OcspRevocationStatus == RevocationStatus.None && result.RevocationResult.IsRevokedCRL)
{
    builder.AppendLine("CRL is revoked.");
}

builder.AppendLine();
builder.AppendLine("--------Revocation Information---------");
builder.AppendLine();

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
//Save to file
File.WriteAllText(Path.GetFullPath(@"Output/Output.txt"),builder.ToString());