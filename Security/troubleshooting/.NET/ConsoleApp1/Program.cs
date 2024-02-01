using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using System.Security.Cryptography;

// Open a FileStream for reading the PDF file.
FileStream fileStream = new FileStream("OwnerPasswordOnly.pdf", FileMode.Open, FileAccess.Read);
// Load the PDF document from the FileStream with the specified owner password.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(fileStream, "12345");
// Access the security settings of the loaded PDF document.
PdfSecurity security = loadedDocument.Security;
// Disable incremental update for the file structure.
loadedDocument.FileStructure.IncrementalUpdate = false;
// Set specific permissions for a PDF document.
loadedDocument.Security.Permissions = PdfPermissionsFlags.EditAnnotations | PdfPermissionsFlags.AssembleDocument;
// Set the encryption algorithm to AES for the document security.
security.Algorithm = PdfEncryptionAlgorithm.AES;
// Set the owner password for a PDF document.
security.OwnerPassword = "";
// Set the user password for a PDF document.
security.UserPassword = "";
// Create a MemoryStream to store the modified PDF document.
MemoryStream stream = new MemoryStream();
// Save the modified PDF document to the MemoryStream.
loadedDocument.Save(stream);
// Write the contents of the MemoryStream.
File.WriteAllBytes("output.pdf", stream.ToArray());
// Close the loaded PDF document.
loadedDocument.Close(true);
