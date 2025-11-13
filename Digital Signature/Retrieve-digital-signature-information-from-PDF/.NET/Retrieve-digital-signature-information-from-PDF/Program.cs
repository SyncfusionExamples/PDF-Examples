using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;

//Load the PDF document.
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the signature field from PdfLoadedDocument form field collection.
    PdfLoadedSignatureField signatureField = loadedDocument.Form.Fields[0] as PdfLoadedSignatureField;
    PdfSignature signature = signatureField.Signature;
    //Extract the signature information.
    Console.WriteLine("Digitally Signed by: " + signature.Certificate.IssuerName);
    Console.WriteLine("Valid From: " + signature.Certificate.ValidFrom);
    Console.WriteLine("Valid To: " + signature.Certificate.ValidTo);
    Console.WriteLine("Hash Algorithm : " + signature.Settings.DigestAlgorithm);
    Console.WriteLine("Cryptographics Standard : " + signature.Settings.CryptographicStandard);
}
