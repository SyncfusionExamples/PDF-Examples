using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get stream from the text file. 
    Stream fileStream = new FileStream(Path.GetFullPath("Data/Input.txt"), FileMode.Open, FileAccess.Read);

    //Creates an attachment.
    PdfAttachment attachment = new PdfAttachment("Input.txt", fileStream);
    attachment.ModificationDate = DateTime.Now;
    attachment.Description = "Input.txt";
    attachment.MimeType = "application/txt";

    //Create attachment. 
    if (loadedDocument.Attachments == null)
        loadedDocument.CreateAttachment();

    //Add the attachment to the document.
    loadedDocument.Attachments.Add(attachment);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}