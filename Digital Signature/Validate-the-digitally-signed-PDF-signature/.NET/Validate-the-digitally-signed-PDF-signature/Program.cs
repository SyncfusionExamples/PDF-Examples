// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using System.Security.Cryptography.X509Certificates;

//Get the stream from the document.
FileStream documentStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load an existing signed PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(documentStream);

//Get signature field.
PdfLoadedSignatureField signatureField = loadedDocument.Form.Fields[0] as PdfLoadedSignatureField;

//X509Certificate2Collection to check the signer's identity using root certificates.
X509CertificateCollection collection = new X509CertificateCollection();

//Creates a certificate instance from PFX file with private key.
FileStream certificateStream = new FileStream(Path.GetFullPath("../../../PDF.pfx"), FileMode.Open, FileAccess.Read);
byte[] data = new byte[certificateStream.Length];
certificateStream.Read(data, 0, data.Length);

//Create new X509Certificate2 with the root certificate.
X509Certificate2 certificate = new X509Certificate2(data, "syncfusion");

//Add the certificate to the collection.
collection.Add(certificate);

//Validate signature and get the validation result.
PdfSignatureValidationResult result = signatureField.ValidateSignature(collection);

//Checks whether the signature is valid or not.
SignatureStatus status = result.SignatureStatus;

//Checks whether the document is modified or not.
bool isModified = result.IsDocumentModified;

//Signature details.
string issuerName = signatureField.Signature.Certificate.IssuerName;
DateTime validFrom = signatureField.Signature.Certificate.ValidFrom;
DateTime validTo = signatureField.Signature.Certificate.ValidTo;
string signatureAlgorithm = result.SignatureAlgorithm;
DigestAlgorithm digestAlgorithm = result.DigestAlgorithm;

//Revocation validation details.
RevocationResult revocationDetails = result.RevocationResult;
RevocationStatus revocationStatus = revocationDetails.OcspRevocationStatus;
bool isRevokedCRL = revocationDetails.IsRevokedCRL;

//Close the document.
loadedDocument.Close(true);
