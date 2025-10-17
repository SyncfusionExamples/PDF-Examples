using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Create a new document with PDF/A-3u standard.
PdfDocument document = new PdfDocument(PdfConformanceLevel.Pdf_A3U);

//Add a page to the document.
PdfPage page = document.Pages.Add();

//Get stream from the text file.
Stream fileStream = new FileStream(Path.GetFullPath(@"Data/Input.txt"), FileMode.Open, FileAccess.Read);

//Creates the attachment. 
PdfAttachment attachment = new PdfAttachment(@"Data/Input.txt", fileStream);
attachment.Relationship = PdfAttachmentRelationship.Alternative;
attachment.ModificationDate = DateTime.Now;
attachment.Description = "Input.txt";
attachment.MimeType = "application/txt";

//Adds the attachment to the document.
document.Attachments.Add(attachment);

//Create PDF graphics for the page.
PdfGraphics graphics = page.Graphics;

//Get stream from the font file. 
FileStream fontStream = new FileStream(Path.GetFullPath(@"Data/Arial.ttf"), FileMode.Open, FileAccess.Read);

//Load the TrueType font from the local file.
PdfFont font = new PdfTrueTypeFont(fontStream, 14);

//Draw the text.
graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(0, 0));

//Save the PDF document
document.Save(Path.GetFullPath(@"Output/Output.pdf"));

//Close the document.
document.Close(true);