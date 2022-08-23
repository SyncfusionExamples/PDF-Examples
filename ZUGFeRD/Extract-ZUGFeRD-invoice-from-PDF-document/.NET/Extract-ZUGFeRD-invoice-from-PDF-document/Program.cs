// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Iterates the attachments.
foreach (PdfAttachment attachment in loadedDocument.Attachments)
{
    //Extracts the ZUGFeRD invoice attachment and saves it to the disk.
    FileStream s = new FileStream(attachment.FileName, FileMode.Create, FileAccess.Write);
    s.Write(attachment.Data, 0, attachment.Data.Length);
    s.Dispose();
}

//Close the PDF document. 
loadedDocument.Close(true);
