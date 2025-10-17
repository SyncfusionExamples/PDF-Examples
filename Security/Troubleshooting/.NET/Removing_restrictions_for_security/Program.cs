using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using System.Security.Cryptography;

// Load the PDF document from the FileStream with the specified owner password.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/OwnerPasswordOnly.pdf"), "12345");
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

// Save the modified PDF document
loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
// Close the loaded PDF document.
loadedDocument.Close(true);
