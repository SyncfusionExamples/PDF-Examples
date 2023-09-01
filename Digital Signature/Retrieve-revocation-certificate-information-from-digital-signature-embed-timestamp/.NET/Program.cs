// See https://aka.ms/new-console-template for more information
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using System.Reflection.Metadata;
//Load a PDF document
FileStream docStream = new FileStream("../../../Input.pdf", FileMode.Open, FileAccess.Read);
PdfLoadedDocument document = new PdfLoadedDocument(docStream);
//Gets the signature field.
PdfLoadedSignatureField signatureField = document.Form.Fields[0] as PdfLoadedSignatureField;
//Validates signature and gets the validation result.
PdfSignatureValidationResult result = signatureField.ValidateSignature();
//Gets signer certificates
PdfSignerCertificate[] certifcate = result.TimeStampInformation.SignerCertificates;
//Print the certifcate value
for(int i = 0;i < certifcate.Length; i++)
{
    Console.WriteLine(certifcate[i].Certificate);
}
//Close the document.
document.Close(true);
