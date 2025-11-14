using Syncfusion.Pdf;
using Syncfusion.Pdf.Security;

//Create a new pdf document.
using (PdfDocument document = new PdfDocument())
{
    //Adds a new page.
    PdfPage page = document.Pages.Add();
    //Creates a digital signature.
    PdfSignature signature = new PdfSignature(page, "Signature");
    //Add the time stamp by using the server URI.
    signature.TimeStampServer = new TimeStampServer(new Uri("http://time.certum.pl/"));
    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

