// Open a FileStream for reading the PDF file.
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using System.Security.Cryptography;

FileStream fileStream = new FileStream(Path.GetFullPath(@"Data/OwnerPasswordOnly.pdf"), FileMode.Open, FileAccess.Read);
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
// Set the encryption key size to 256 Bit.
security.KeySize = PdfEncryptionKeySize.Key256Bit;
// Create a MemoryStream to store the modified PDF document.
MemoryStream stream = new MemoryStream();
// Save the modified PDF document to the MemoryStream.
loadedDocument.Save(stream);
// Close the loaded PDF document.
loadedDocument.Close(true);
// Write the contents of the MemoryStream.
File.WriteAllBytes((@"Output/Output.pdf"), stream.ToArray());
