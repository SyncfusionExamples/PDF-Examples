using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;

//Load the PDF document.
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Gets the page.
    PdfLoadedPage page = loadedDocument.Pages[0] as PdfLoadedPage;
    //Creates a digital signature.
    PdfSignature signature = new PdfSignature(page, "Signature");
    //Add the time stamp by using the server URI.
    signature.TimeStampServer = new TimeStampServer(new Uri("http://time.certum.pl/"));
    //Save the PDF document 
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
