using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;

//Load the PDF document
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Get the first page of the document
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;
    // Define a redaction area and set its color to black
    PdfRedaction redaction = new PdfRedaction(new RectangleF(340, 120, 140, 20), Color.Black);
    // Add the redaction to the page
    loadedPage.AddRedaction(redaction);
    // Apply the redaction to remove content
    loadedDocument.Redact();
    // Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}