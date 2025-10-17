using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Load the first page.
    PdfLoadedPage page = loadedDocument.Pages[0] as PdfLoadedPage;

    //Create PDF redaction for the page. 
    PdfRedaction redaction = new PdfRedaction(new RectangleF(343, 147, 60, 17), Color.Black);

    //Add redaction to the loaded page
    page.AddRedaction(redaction);

    //Redact the contents from PDF document
    List<PdfRedactionResult> redactionResults = loadedDocument.Redact();

    foreach (PdfRedactionResult result in redactionResults)
    {
        if (result.IsRedactionSuccess)
            Console.WriteLine("Content redacted successfully...");
        else
            Console.WriteLine("Content not redacted properly...");
    }

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}