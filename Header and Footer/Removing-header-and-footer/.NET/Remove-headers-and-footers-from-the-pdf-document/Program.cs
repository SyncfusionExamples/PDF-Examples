using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;

// Load the PDF document

using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/HeadersAndFooters.pdf")))
{

    PdfLoadedPage page1 = loadedDocument.Pages[0] as PdfLoadedPage;

    float width = page1.Size.Width;

    float height = page1.Size.Height;

    //Create a redaction object

    PdfRedaction redaction = new PdfRedaction(new RectangleF(520, height - 90, width, 50));

    //Add a redaction object into the redaction collection of loaded page

    page1.AddRedaction(redaction);

    //Redact the contents from the PDF document

    loadedDocument.Redact();

    //Save the PDF document

    loadedDocument.Save(Path.GetFullPath("Output/Output.pdf"));
}