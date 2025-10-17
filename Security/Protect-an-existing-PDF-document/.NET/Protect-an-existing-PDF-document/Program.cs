using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Gets a security object for the document
    PdfSecurity security = loadedDocument.Security;

    // Configure key size and encryption algorithm
    security.KeySize = PdfEncryptionKeySize.Key256Bit;
    security.Algorithm = PdfEncryptionAlgorithm.AES;

    // Assign owner and user passwords
    security.OwnerPassword = "owner123";
    security.UserPassword = "user123";
    
    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}