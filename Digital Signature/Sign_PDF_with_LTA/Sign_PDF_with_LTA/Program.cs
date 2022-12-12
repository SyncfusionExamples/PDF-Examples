using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using Syncfusion.Pdf;

FileStream documentStream1 = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(documentStream1);
//Load digital ID with password.
FileStream documentStream2 = new FileStream(Path.GetFullPath("../../../DigitalSignatureTest.pfx"), FileMode.Open, FileAccess.Read);
PdfCertificate certificate = new PdfCertificate(documentStream2, "DigitalPass123");

//Create a signature with loaded digital ID.
PdfSignature signature = new PdfSignature(loadedDocument, loadedDocument.Pages[0], certificate, "DigitalSignature");
signature.Settings.CryptographicStandard = CryptographicStandard.CADES;
signature.Settings.DigestAlgorithm = DigestAlgorithm.SHA256;
signature.TimeStampServer = new TimeStampServer(new Uri("http://timestamping.ensuredca.com"));
//Enable LTV document.
signature.EnableLtv = true;

//Save the PDF document.
MemoryStream stream = new MemoryStream();
loadedDocument.Save(stream);
//Close the document.
loadedDocument.Close(true);

//Load existing PDF document.
PdfLoadedDocument ltDocument = new PdfLoadedDocument(stream);
//Load the existing PDF page.
PdfLoadedPage lpage = ltDocument.Pages[0] as PdfLoadedPage;

//Create PDF signature with empty certificate.
PdfSignature timeStamp = new PdfSignature(lpage, "timestamp");
timeStamp.TimeStampServer = new TimeStampServer(new Uri("http://timestamping.ensuredca.com"));

//Save and close the PDF document
MemoryStream stream1 = new MemoryStream();
ltDocument.Save(stream1);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    ltDocument.Save(outputFileStream);
}

//Close the document.
ltDocument.Close(true);