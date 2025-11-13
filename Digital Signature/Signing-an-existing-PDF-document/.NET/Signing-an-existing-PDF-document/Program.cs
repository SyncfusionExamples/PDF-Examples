using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;

//Load the PDF document.
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Gets the first page of the document.
    PdfLoadedPage page = loadedDocument.Pages[0] as PdfLoadedPage;
    //Gets the first signature field of the PDF document.
    PdfLoadedSignatureField field = loadedDocument.Form.Fields[0] as PdfLoadedSignatureField;
    //Creates a certificate.
    FileStream certificateStream = new FileStream(Path.GetFullPath(@"Data/PDF.pfx"), FileMode.Open, FileAccess.Read);
    PdfCertificate certificate = new PdfCertificate(certificateStream, "syncfusion");
    //Add digital signature to signature field. 
    field.Signature = new PdfSignature(loadedDocument, page, certificate, "Signature", field);
    //Save the PDF document 
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}