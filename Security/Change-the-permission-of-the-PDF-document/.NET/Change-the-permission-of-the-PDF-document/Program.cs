using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf"), "syncfusion");

//Change the permission.
loadedDocument.Security.Permissions = PdfPermissionsFlags.CopyContent | PdfPermissionsFlags.AssembleDocument;

//Save the PDF document
loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));

//Close the document.
loadedDocument.Close(true);
