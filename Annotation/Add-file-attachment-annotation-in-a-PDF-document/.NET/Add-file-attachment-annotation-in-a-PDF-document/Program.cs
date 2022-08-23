// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Creates a new PDF Document.
PdfDocument document = new PdfDocument();

//Creates a new page.
PdfPage page = document.Pages.Add();

//Creates a new rectangle.
RectangleF attachmentRectangle = new RectangleF(10, 40, 30, 30);

//Load the PDF document.
FileStream inputStream = new FileStream(Path.GetFullPath("../../../logo.png"), FileMode.Open, FileAccess.Read);

//Creates a new attachment annotation.
PdfAttachmentAnnotation attachmentAnnotation = new PdfAttachmentAnnotation(attachmentRectangle, @"logo.png", inputStream);

//Sets the attachment icon to attachment annotation.
attachmentAnnotation.Icon = PdfAttachmentIcon.PushPin;

//Adds this annotation to a new page.
page.Annotations.Add(attachmentAnnotation);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
