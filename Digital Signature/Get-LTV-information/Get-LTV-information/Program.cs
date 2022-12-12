

using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;

//Gets the stream from the document
FileStream documentStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Loads an existing signed PDF document

PdfLoadedDocument document = new PdfLoadedDocument(documentStream);

// Gets the signature field

PdfLoadedSignatureField signatureField = document.Form.Fields[0] as PdfLoadedSignatureField;

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

// Closes the document

document.Close(true);