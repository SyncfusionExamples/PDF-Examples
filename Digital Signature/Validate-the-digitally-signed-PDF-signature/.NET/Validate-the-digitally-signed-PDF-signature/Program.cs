// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using System.Security.Cryptography.X509Certificates;

// Load the input PDF document stream from the specified file path
using (FileStream documentStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
{

    // Load the signed PDF document using the stream
    using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(documentStream))
    {

        // Retrieve the first signature field from the PDF form
        PdfLoadedSignatureField signatureField = loadedDocument.Form.Fields[0] as PdfLoadedSignatureField;

        // Create a certificate collection to hold trusted root certificates for validation
        X509CertificateCollection collection = new X509CertificateCollection();

        // Load the root certificate from a PFX file (includes private key)
        FileStream certificateStream = new FileStream(Path.GetFullPath(@"Data/PDF.pfx"), FileMode.Open, FileAccess.Read);
        byte[] data = new byte[certificateStream.Length];
        certificateStream.Read(data, 0, data.Length);

        // Create an X509Certificate2 instance using the loaded certificate data and password
        X509Certificate2 certificate = new X509Certificate2(data, "syncfusion");

        // Add the certificate to the validation collection
        collection.Add(certificate);

        // Validate the signature using the provided certificate collection
        PdfSignatureValidationResult result = signatureField.ValidateSignature(collection);

        // Check if the signature is valid
        SignatureStatus status = result.SignatureStatus;

        // Check if the document has been modified after signing
        bool isModified = result.IsDocumentModified;

        // Check if Long-Term Validation (LTV) is enabled in the signature
        bool isLtvEnabled = result.LtvVerificationInfo.IsLtvEnabled;

        // Check if Certificate Revocation List (CRL) data is embedded in the PDF
        bool isCrlEmbedded = result.LtvVerificationInfo.IsCrlEmbedded;

        // Check if Online Certificate Status Protocol (OCSP) data is embedded in the PDF
        bool isOcspEmbedded = result.LtvVerificationInfo.IsOcspEmbedded;

        // Output the validation results to the console
        Console.WriteLine("Document modified: " + isModified);
        Console.WriteLine("LTV enabled: " + isLtvEnabled);
        Console.WriteLine("CRL embedded: " + isCrlEmbedded);
        Console.WriteLine("OCSP embedded: " + isOcspEmbedded);

        // Extract and display signature certificate details
        string issuerName = signatureField.Signature.Certificate.IssuerName;
        DateTime validFrom = signatureField.Signature.Certificate.ValidFrom;
        DateTime validTo = signatureField.Signature.Certificate.ValidTo;
        string signatureAlgorithm = result.SignatureAlgorithm;
        DigestAlgorithm digestAlgorithm = result.DigestAlgorithm;

        Console.WriteLine("Issuer Name: " + issuerName);
        Console.WriteLine("Valid From: " + validFrom);
        Console.WriteLine("Valid To: " + validTo);
        Console.WriteLine("Signature Algorithm: " + signatureAlgorithm);
        Console.WriteLine("Digest Algorithm: " + digestAlgorithm);

        // Extract and display revocation validation details
        RevocationResult revocationDetails = result.RevocationResult;
        RevocationStatus revocationStatus = revocationDetails.OcspRevocationStatus;
        bool isRevokedCRL = revocationDetails.IsRevokedCRL;

        Console.WriteLine("Revocation Status: " + revocationStatus);
        Console.WriteLine("Is Revoked CRL: " + isRevokedCRL);

        // Close the loaded PDF document and release resources
        loadedDocument.Close(true);
    }
}
