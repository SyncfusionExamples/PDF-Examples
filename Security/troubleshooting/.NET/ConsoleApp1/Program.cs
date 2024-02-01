using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using System.Security.Cryptography;

FileStream fileStream = new FileStream("OwnerPasswordOnly.pdf", FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(fileStream, "12345");
PdfSecurity security = loadedDocument.Security;
loadedDocument.FileStructure.IncrementalUpdate = false;
loadedDocument.Security.Permissions = PdfPermissionsFlags.EditAnnotations | PdfPermissionsFlags.AssembleDocument;
security.Algorithm = PdfEncryptionAlgorithm.AES;
security.OwnerPassword = "";
security.UserPassword = "";
MemoryStream stream = new MemoryStream();
loadedDocument.Save(stream);
File.WriteAllBytes("output.pdf", stream.ToArray());
loadedDocument.Close(true);
