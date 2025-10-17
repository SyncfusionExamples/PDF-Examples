using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //PDF document security.
    PdfSecurity security = loadedDocument.Security;

    //Specifies encryption key size, algorithm and permission.
    security.KeySize = PdfEncryptionKeySize.Key256Bit;
    security.Algorithm = PdfEncryptionAlgorithm.AES;

    //Provide user password.
    security.UserPassword = "password";

    //Specifies encryption option.
    security.EncryptionOptions = PdfEncryptionOptions.EncryptOnlyAttachments;

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
