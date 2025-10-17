using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Removes an attachment.
    loadedDocument.Attachments.RemoveAt(0);

    //PdfAttachment attachment = document.Attachments[0];
    //document.Attachments.Remove(attachment);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
