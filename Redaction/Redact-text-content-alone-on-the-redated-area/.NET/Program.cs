using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;
using Syncfusion.Drawing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    PdfRedaction redaction = new PdfRedaction(new RectangleF(150, 150, 60, 24), Color.Transparent);
    //Only the text within the redaction bounds should be redacted.
    redaction.TextOnly = true;
    foreach (PdfLoadedPage loadedPage in loadedDocument.Pages)
    {
        loadedPage.AddRedaction(redaction);
    }
    loadedDocument.Redact();

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
