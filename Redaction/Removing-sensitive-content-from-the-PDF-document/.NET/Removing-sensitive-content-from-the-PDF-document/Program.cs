// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;

//Create stream from an existing PDF document. 
using (FileStream docStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
{
    //Load the PDF document from stream
    using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream))
    {
        PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;
        //Create a PDF redaction for the page
        PdfRedaction redaction = new PdfRedaction(new RectangleF(340, 120, 140, 20), Color.Black);
        //Add a redaction object into the redaction collection of loaded page.
        loadedPage.AddRedaction(redaction);
        //Redact the contents from the PDF document.
        loadedDocument.Redact();

        //Save the redacted PDF document to the memory stream
        using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
        {
            loadedDocument.Save(outputFileStream);
        }
    }
}