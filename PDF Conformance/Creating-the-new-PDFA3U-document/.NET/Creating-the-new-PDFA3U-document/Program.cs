// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Create a new document with PDF/A-3u standard.
PdfDocument document = new PdfDocument(PdfConformanceLevel.Pdf_A3U);

//Add a page to the document.
PdfPage page = document.Pages.Add();

//Get stream from the text file.
Stream fileStream = new FileStream(Path.GetFullPath("../../../Input.txt"), FileMode.Open, FileAccess.Read);

//Creates the attachment. 
PdfAttachment attachment = new PdfAttachment("Input.txt", fileStream);
attachment.Relationship = PdfAttachmentRelationship.Alternative;
attachment.ModificationDate = DateTime.Now;
attachment.Description = "Input.txt";
attachment.MimeType = "application/txt";

//Adds the attachment to the document.
document.Attachments.Add(attachment);

//Create PDF graphics for the page.
PdfGraphics graphics = page.Graphics;

//Get stream from the font file. 
FileStream fontStream = new FileStream(Path.GetFullPath("../../../Arial.ttf"), FileMode.Open, FileAccess.Read);

//Load the TrueType font from the local file.
PdfFont font = new PdfTrueTypeFont(fontStream, 14);

//Draw the text.
graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(0, 0));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);