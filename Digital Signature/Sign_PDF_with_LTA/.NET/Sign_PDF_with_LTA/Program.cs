using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using Syncfusion.Pdf;

//Load the PDF document
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Load digital ID with password.
    FileStream documentStream2 = new FileStream(Path.GetFullPath(@"Data/DigitalSignatureTest.pfx"), FileMode.Open, FileAccess.Read);
    PdfCertificate certificate = new PdfCertificate(documentStream2, "DigitalPass123");
    //Create a signature with loaded digital ID.
    PdfSignature signature = new PdfSignature(loadedDocument, loadedDocument.Pages[0], certificate, "DigitalSignature");
    signature.Settings.CryptographicStandard = CryptographicStandard.CADES;
    signature.Settings.DigestAlgorithm = DigestAlgorithm.SHA256;
    signature.TimeStampServer = new TimeStampServer(new Uri("http://time.certum.pl"));
    //Enable LTV document.
    signature.EnableLtv = true;
    //Save the PDF document.
    MemoryStream stream = new MemoryStream();
    loadedDocument.Save(stream);

    //Load existing PDF document.
    using (PdfLoadedDocument ltDocument = new PdfLoadedDocument(stream))
    {
        //Load the existing PDF page.
        PdfLoadedPage lpage = ltDocument.Pages[0] as PdfLoadedPage;
        //Create PDF signature with empty certificate.
        PdfSignature timeStamp = new PdfSignature(lpage, "timestamp");
        timeStamp.TimeStampServer = new TimeStampServer(new Uri("http://time.certum.pl"));
        //Save the PDF document.
        ltDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
    }
}