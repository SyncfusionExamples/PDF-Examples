﻿using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;

//Gets the stream from the document
FileStream documentStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read);

//Loads an existing signed PDF document
PdfLoadedDocument document = new PdfLoadedDocument(documentStream);

// Gets the signature field
PdfLoadedSignatureField signatureField = document.Form.Fields[0] as PdfLoadedSignatureField;

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

// Closes the document
document.Close(true);