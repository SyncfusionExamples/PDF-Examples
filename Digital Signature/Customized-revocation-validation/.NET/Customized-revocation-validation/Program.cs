using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;

//Load the PDF document.
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Gets the signature field
    PdfLoadedSignatureField signatureField = loadedDocument.Form.Fields[0] as PdfLoadedSignatureField;
    // Signature validation options
    PdfSignatureValidationOptions options = new PdfSignatureValidationOptions();
    // Sets the revocation type
    options.RevocationValidationType = RevocationValidationType.Crl;
    // Validate signature and get validation result
    PdfSignatureValidationResult result = signatureField.ValidateSignature(options);
    //Check whether the CRL is revoked
    if (result.RevocationResult.IsRevokedCRL)
    {
        Console.WriteLine("CRL is revoked");
    }
    else
    {
        Console.WriteLine("CRL is not revoked");
    }
}