// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Create a new document with PDF/A-3b standard.
PdfDocument document = new PdfDocument(PdfConformanceLevel.Pdf_A3B);

//Add a page to the document.
PdfPage page = document.Pages.Add();

//Get stream from the input text file attachment. 
Stream fileStream = new FileStream(Path.GetFullPath("../../../Input.txt"), FileMode.Open, FileAccess.Read);

//Creates the attachment with some properties. 
PdfAttachment attachment = new PdfAttachment("Input.txt", fileStream);
attachment.Relationship = PdfAttachmentRelationship.Alternative;
attachment.ModificationDate = DateTime.Now;
attachment.Description = "Input.txt";
attachment.MimeType = "application/txt";

//Adds the attachment to the document.
document.Attachments.Add(attachment);

//Create PDF graphics for the page.
PdfGraphics graphics = page.Graphics;

//Load the TrueType font from the local file.
FileStream fontStream = new FileStream(Path.GetFullPath("../../../Arial.ttf"), FileMode.Open, FileAccess.Read);

//Create the PDF true type font. 
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
