using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the first page from the document.
    PdfLoadedPage page = loadedDocument.Pages[0] as PdfLoadedPage;

    //Create a PDF redaction for the page.
    PdfRedaction redaction = new PdfRedaction(new RectangleF(63, 57, 182, 157));

    //Get stream from the image file.
    FileStream imageStream = new FileStream(Path.GetFullPath(@"Data/image.jpg"), FileMode.Open, FileAccess.Read);

    //Load the image file. 
    PdfImage image = new PdfBitmap(imageStream);

    //Draw image on the redaction appearance. 
    redaction.Appearance.Graphics.DrawImage(image, new RectangleF(0, 0, 182, 157));

    //Add a redaction object into the redaction collection of loaded page.
    page.AddRedaction(redaction);

    //Redact the contents from the PDF document.
    loadedDocument.Redact();

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
