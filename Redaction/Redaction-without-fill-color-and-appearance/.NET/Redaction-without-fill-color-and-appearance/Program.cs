using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the first page from the document.
    PdfLoadedPage page = loadedDocument.Pages[0] as PdfLoadedPage;

    //Create a PDF redaction for the page.
    PdfRedaction redaction = new PdfRedaction(new RectangleF(343, 147, 60, 17));

    //Add a redaction object into the redaction collection of loaded page.
    page.AddRedaction(redaction);

    //Redact the contents from the PDF document.
    loadedDocument.Redact();

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}