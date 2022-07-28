// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;

//Get stream from the existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Removes an attachment.
loadedDocument.Attachments.RemoveAt(0);

//PdfAttachment attachment = document.Attachments[0];
//document.Attachments.Remove(attachment);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
