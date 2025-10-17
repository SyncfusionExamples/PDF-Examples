using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Creates a new page.
    PdfPage page = document.Pages.Add();

    //Creates a new rectangle.
    RectangleF attachmentRectangle = new RectangleF(10, 40, 30, 30);

    //Load the PDF document.
    FileStream inputStream = new FileStream(Path.GetFullPath(@"Data/logo.png"), FileMode.Open, FileAccess.Read);

    //Creates a new attachment annotation.
    PdfAttachmentAnnotation attachmentAnnotation = new PdfAttachmentAnnotation(attachmentRectangle, @"logo.png", inputStream);

    //Sets the attachment icon to attachment annotation.
    attachmentAnnotation.Icon = PdfAttachmentIcon.PushPin;

    //Adds this annotation to a new page.
    page.Annotations.Add(attachmentAnnotation);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
