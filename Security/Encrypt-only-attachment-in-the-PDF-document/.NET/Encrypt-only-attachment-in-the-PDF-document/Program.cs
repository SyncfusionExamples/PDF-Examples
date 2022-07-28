// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Security;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add page to the document. 
PdfPage page = document.Pages.Add();

//Create PDF graphics for the page. 
PdfGraphics graphics = page.Graphics;

//Set the font. 
PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 20f, PdfFontStyle.Bold);

//Set the brush. 
PdfBrush brush = PdfBrushes.Black;

//Document security.
PdfSecurity security = document.Security;

//Specifies key size and encryption algorithm.
security.KeySize = PdfEncryptionKeySize.Key256Bit;
security.Algorithm = PdfEncryptionAlgorithm.AES;

//Specifies encryption option.
security.EncryptionOptions = PdfEncryptionOptions.EncryptOnlyAttachments;
security.UserPassword = "password";

//Draw the text. 
graphics.DrawString("Encrypted only attachments with AES 256bit", font, brush, new PointF(0, 40));

//Creates an attachment.
FileStream textFileStream = new FileStream(Path.GetFullPath(@"../../../input.txt"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
PdfAttachment attachment = new PdfAttachment("input.txt", textFileStream);
attachment.ModificationDate = DateTime.Now;
attachment.Description = "Input.txt";
attachment.MimeType = "application/txt";

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