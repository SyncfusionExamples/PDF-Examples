using Syncfusion.Pdf.Parsing;

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf"), "password");

//Change the user password .
loadedDocument.Security.UserPassword = "NewPassword";

//Save the PDF document
loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));

//Close the document.
loadedDocument.Close(true);
