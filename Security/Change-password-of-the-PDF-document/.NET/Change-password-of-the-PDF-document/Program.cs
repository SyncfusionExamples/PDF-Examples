// See https://aka.ms/new-console-template for more information

//Get stream from an existing PDF document. 
using Syncfusion.Pdf.Parsing;

FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream, "password");

//Change the user password .
loadedDocument.Security.UserPassword = "NewPassword";

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
