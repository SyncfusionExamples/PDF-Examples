using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Iterates the attachments.
    foreach (PdfAttachment attachment in loadedDocument.Attachments)
    {
        //Extracts the attachment and saves it to the disk.
        FileStream s = new FileStream(Path.GetFullPath(@"Output/" + attachment.FileName), FileMode.Create);
        s.Write(attachment.Data, 0, attachment.Data.Length);
        s.Dispose();
    }

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
