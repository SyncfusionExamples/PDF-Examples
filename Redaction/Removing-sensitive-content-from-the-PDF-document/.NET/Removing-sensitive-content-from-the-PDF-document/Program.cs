using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;
    //Create a PDF redaction for the page
    PdfRedaction redaction = new PdfRedaction(new RectangleF(340, 120, 140, 20), Color.Black);
    //Add a redaction object into the redaction collection of loaded page.
    loadedPage.AddRedaction(redaction);
    //Redact the contents from the PDF document.
    loadedDocument.Redact();

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}