// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;

// Load the PDF document from a file stream
using (FileStream inputFileStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
{
    // Load the PDF document
    PdfLoadedDocument document = new PdfLoadedDocument(inputFileStream);

    //  Gets a security object for the document
    PdfSecurity security = document.Security;

    // Configure key size and encryption algorithm
    security.KeySize = PdfEncryptionKeySize.Key256Bit;
    security.Algorithm = PdfEncryptionAlgorithm.AES;

    // Assign owner and user passwords
    security.OwnerPassword = "owner123";
    security.UserPassword = "user123";

    //Create file stream.
    using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
    {
        //Save the PDF document to file stream.
        document.Save(outputFileStream);
    }

    // Close the document
    document.Close(true);
}
