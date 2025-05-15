using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using System.IO;

namespace Make_a_PDF_read_only
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Load an existing PDF document from disk
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../Data/Input.pdf");

            // Access the security settings of the PDF document
            PdfSecurity security = loadedDocument.Security;

            // Set the encryption algorithm to AES (Advanced Encryption Standard)
            security.Algorithm = PdfEncryptionAlgorithm.AES;

            // Set the encryption key size to 128-bit for a balance of security and performance
            security.KeySize = PdfEncryptionKeySize.Key128Bit;

            // Set the owner password (required to enforce permissions)
            security.OwnerPassword = "Syncfusion";

            //It allows printing and accessibility copy content.
            security.Permissions = PdfPermissionsFlags.Print | PdfPermissionsFlags.AccessibilityCopyContent;

            // Set an optional user password (required to open the PDF)
            security.UserPassword = "password";

            // Save the updated and secured PDF document to a new file
            loadedDocument.Save("../../Output/Output.pdf");

            // Close and dispose of the loaded PDF document to release resources
            loadedDocument.Close(true);
        }
    }
}
