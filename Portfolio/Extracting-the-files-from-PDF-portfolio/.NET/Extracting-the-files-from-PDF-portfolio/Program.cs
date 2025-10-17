using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
PdfLoadedDocument document = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf"));

string outputFileName = "";

//Iterate the attachments.
foreach (PdfAttachment attachment in document.Attachments)
{
    //Extract the attachment and save to the disk.
    FileStream s = new FileStream(attachment.FileName, FileMode.Create);
    s.Write(attachment.Data, 0, attachment.Data.Length);
    s.Dispose();

    outputFileName = attachment.FileName;
}
//Save the PDF document
document.Save(Path.GetFullPath(@"Output/Output.pdf"));
//Close the document.
document.Close(true);
