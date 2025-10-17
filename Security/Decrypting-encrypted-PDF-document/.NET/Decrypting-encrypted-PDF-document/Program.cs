using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;

    // Load the encrypted PDF document
    PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf"), "syncfusion");

    // Set the document permissions to default (removes any restrictions)
    loadedDocument.Security.Permissions = PdfPermissionsFlags.Default;

    // Clear the owner and user passwords to decrypt the document
    loadedDocument.Security.OwnerPassword = string.Empty;
    loadedDocument.Security.UserPassword = string.Empty;

    // Save the decrypted PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
    // Close the loaded PDF document
    loadedDocument.Close(true);
