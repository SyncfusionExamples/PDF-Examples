using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create PDF document with PDF/A-3B conformance. 
PdfDocument document = new PdfDocument(PdfConformanceLevel.Pdf_A3B);

//Set the document conformance level. 
document.ZugferdConformanceLevel = ZugferdConformanceLevel.Basic;

//Get stream from the XML file
FileStream invoiceStream = new FileStream(Path.GetFullPath(@"Data/ZUGFeRD_invoice.xml"), FileMode.Open, FileAccess.Read);

//Create an attachment with some properties.
PdfAttachment attachment = new PdfAttachment("ZUGFeRD-invoice.xml", invoiceStream);
attachment.Relationship = PdfAttachmentRelationship.Alternative;
attachment.ModificationDate = DateTime.Now;
attachment.Description = "ZUGFeRD-invoice";
attachment.MimeType = "application/xml";

//Add the attachment to the document. 
document.Attachments.Add(attachment);

//Save the PDF document to file stream.
document.Save(Path.GetFullPath(@"Output/Output.pdf"));

//Close the document.
document.Close(true);
