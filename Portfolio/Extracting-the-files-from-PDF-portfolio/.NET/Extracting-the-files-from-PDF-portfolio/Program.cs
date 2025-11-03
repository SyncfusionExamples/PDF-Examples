using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
PdfLoadedDocument document = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf"));
// Iterate through all attachments in the PDF document
foreach (PdfAttachment attachment in document.Attachments)
{
    // Create a file stream to save the attachment to disk using its original file name
    using (FileStream s = new FileStream(attachment.FileName, FileMode.Create))
    {
        // Write the attachment data to the file
        s.Write(attachment.Data, 0, attachment.Data.Length);
    }
    // Retrieve the MIME type of the attachment (e.g., application/pdf, image/png)
    string mimeType = attachment.MimeType;
    Console.WriteLine($"Saved: {attachment.FileName}, MIME Type: {mimeType}");
    // Optional: Access additional metadata if needed
    DateTime creationDate = attachment.CreationDate;
    DateTime modificationDate = attachment.ModificationDate;
    string description = attachment.Description;
    PdfAttachmentRelationship relationship = attachment.Relationship;
    // Log or use the metadata as needed
    Console.WriteLine($"Description: {description}");
    Console.WriteLine($"Created on: {creationDate}, Modified on: {modificationDate}");
    Console.WriteLine($"Relationship: {relationship}");
}
//Save the PDF document
document.Save(Path.GetFullPath(@"Output/Output.pdf"));
//Close the document.
document.Close(true);
