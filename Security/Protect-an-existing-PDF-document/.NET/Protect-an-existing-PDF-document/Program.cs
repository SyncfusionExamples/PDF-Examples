using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Get the security settings of the document
    PdfSecurity security = loadedDocument.Security;
    // Set encryption to AES with a 256-bit key
    security.KeySize = PdfEncryptionKeySize.Key256Bit;
    security.Algorithm = PdfEncryptionAlgorithm.AES;
    // Set owner and user passwords for the document
    security.OwnerPassword = "owner123";
    security.UserPassword = "user123";
    // Save the secured PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}