using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf;

//Create a new PDF document 
PdfDocument document = new PdfDocument(PdfConformanceLevel.Pdf_A3B);
//Set ZUGFeRD conformance level  
document.ZugferdConformanceLevel = ZugferdConformanceLevel.XRechnung;

//Set ZUGFeRD version 
document.ZugferdVersion = ZugferdVersion.FacturX;

// Load the font file as stream 
FileStream fontStream = new FileStream(Path.GetFullPath(@"Data/xrechnung.xml"), FileMode.Open, FileAccess.Read);
//Set an attachment  
PdfAttachment attachment = new PdfAttachment(Path.GetFullPath(@"Data/xrechnung.xml"), fontStream);
attachment.Relationship = PdfAttachmentRelationship.Alternative;
attachment.ModificationDate = DateTime.Now;
attachment.Description = " ZUGFeRD-Xrechnung";
attachment.MimeType = "text/xml";
//Add attachment to PDF document 
document.Attachments.Add(attachment);

//Save the PDF document to file stream.
document.Save(Path.GetFullPath(@"Output/Output.pdf"));

//Close the document.
document.Close(true);
