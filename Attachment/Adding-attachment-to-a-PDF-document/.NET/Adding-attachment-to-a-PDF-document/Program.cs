// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document. 
PdfDocument document = new PdfDocument();

//Get stream from an existing PDF document. 
Stream fileStream = new FileStream(Path.GetFullPath("../../../Input.txt"), FileMode.Open, FileAccess.Read);

//Creates an attachment with properties. 
PdfAttachment attachment = new PdfAttachment("Input.txt", fileStream);
attachment.ModificationDate = DateTime.Now;
attachment.Description = "Input.txt";
attachment.MimeType = "application/txt";

//Adds the attachment to the document.
document.Attachments.Add(attachment);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
