// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Get the stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document.
PdfLoadedDocument document = new PdfLoadedDocument(docStream, "password");

//Accessing the attachments.
foreach (PdfAttachment attachment in document.Attachments)
{
    FileStream stream = new FileStream(attachment.FileName, FileMode.Create);
    stream.Write(attachment.Data, 0, attachment.Data.Length);
    stream.Dispose();
}
    
//Close the document.
document.Close(true);
