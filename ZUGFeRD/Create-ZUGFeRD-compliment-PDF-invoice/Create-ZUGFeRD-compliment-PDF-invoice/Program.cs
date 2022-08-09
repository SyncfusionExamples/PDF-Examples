// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create PDF document with PDF/A-3B conformance. 
PdfDocument document = new PdfDocument(PdfConformanceLevel.Pdf_A3B);

//Set the document conformance level. 
document.ZugferdConformanceLevel = ZugferdConformanceLevel.Basic;

//Get stream from the XML file
FileStream invoiceStream = new FileStream(Path.GetFullPath("../../../ZUGFeRD_invoice.xml"), FileMode.Open, FileAccess.Read);

//Create an attachment with some properties.
PdfAttachment attachment = new PdfAttachment("ZUGFeRD-invoice.xml", invoiceStream);
attachment.Relationship = PdfAttachmentRelationship.Alternative;
attachment.ModificationDate = DateTime.Now;
attachment.Description = "ZUGFeRD-invoice";
attachment.MimeType = "application/xml";

//Add the attachment to the document. 
document.Attachments.Add(attachment);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
