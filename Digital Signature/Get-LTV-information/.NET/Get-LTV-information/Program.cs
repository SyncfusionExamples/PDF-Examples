using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;

//Load the PDF document.
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Gets the signature field
    PdfLoadedSignatureField signatureField = loadedDocument.Form.Fields[0] as PdfLoadedSignatureField;
    // Validates signature and get validation result
    PdfSignatureValidationResult result = signatureField.ValidateSignature();
    // Gets the LTV verification Information.
    LtvVerificationInfo ltvVerificationInfo = result.LtvVerificationInfo;
    // Checks whether the signature document LTV is enabled.
    bool isLtvEnabled = ltvVerificationInfo.IsLtvEnabled;
    // Checks whether the signature document has CRL embedded.
    bool isCrlEmbedded = ltvVerificationInfo.IsCrlEmbedded;
    // Checks whether the signature document has OCSP embedded.
    bool isOcspEmbedded = ltvVerificationInfo.IsOcspEmbedded;
    Console.WriteLine("LTV enabled: " + isLtvEnabled);
    Console.WriteLine("CRL embedded: " + isCrlEmbedded);
    Console.WriteLine("OCSP embedded: " + isOcspEmbedded);
}