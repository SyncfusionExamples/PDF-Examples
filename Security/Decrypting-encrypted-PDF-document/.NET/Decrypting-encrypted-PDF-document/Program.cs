using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;

using (FileStream inputStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
{
    // Load the encrypted PDF document from the input stream
    PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputStream, "syncfusion");

    // Set the document permissions to default (removes any restrictions)
    loadedDocument.Security.Permissions = PdfPermissionsFlags.Default;

    // Clear the owner and user passwords to decrypt the document
    loadedDocument.Security.OwnerPassword = string.Empty;
    loadedDocument.Security.UserPassword = string.Empty;

    using (FileStream outputStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.Write))
    {
        // Save the decrypted PDF document to the output stream
        loadedDocument.Save(outputStream);
    }
    // Close the loaded PDF document and release resources
    loadedDocument.Close(true);
}
