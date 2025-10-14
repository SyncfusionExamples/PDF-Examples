using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Get stream from an existing PDF document. 
    Stream fileStream = new FileStream(Path.GetFullPath(@"Data/Input.txt"), FileMode.Open, FileAccess.Read);

    //Creates an attachment with properties. 
    PdfAttachment attachment = new PdfAttachment("Input.txt", fileStream);
    attachment.ModificationDate = DateTime.Now;
    attachment.Description = "Input.txt";
    attachment.MimeType = "application/txt";

    //Adds the attachment to the document.
    document.Attachments.Add(attachment);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
