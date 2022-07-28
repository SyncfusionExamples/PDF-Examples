// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Get stream from the existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument document = new PdfLoadedDocument(docStream);

//Iterates the attachments.
foreach (PdfAttachment attachment in document.Attachments)
{
    //Extracts the attachment and saves it to the disk.
    FileStream s = new FileStream(Path.GetFullPath("../../../"+ attachment.FileName), FileMode.Create);
    s.Write(attachment.Data, 0, attachment.Data.Length);
    s.Dispose();
}

//Close the document. 
document.Close(true);
