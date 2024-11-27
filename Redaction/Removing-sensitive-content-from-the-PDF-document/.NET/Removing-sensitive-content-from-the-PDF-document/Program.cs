// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;

//Create stream from an existing PDF document. 
using (FileStream docStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
{
    //Load the PDF document from stream
    using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputStream))
    {
        PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;
        //Create a PDF redaction for the page
        PdfRedaction redaction = new PdfRedaction(new RectangleF(340, 120, 140, 20));
        //Add redaction to the first page
        loadedPage.Redactions.Add(redaction);
        //Save the redacted PDF document to the memory stream
        MemoryStream stream = new MemoryStream();
        loadedDocument.Save(stream);
    }
}
