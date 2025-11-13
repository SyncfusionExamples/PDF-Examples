using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Security;

//Create a new pdf document.
using (PdfDocument document = new PdfDocument())
{
    //Adding a new page to the PDF document.
    PdfPageBase page = document.Pages.Add();
    //Creates a certificate instance from the PFX file with a private key.
    FileStream certificateStream = new FileStream(Path.GetFullPath(@"Data/PDF.pfx"), FileMode.Open, FileAccess.Read);
    PdfCertificate pdfCert = new PdfCertificate(certificateStream, "syncfusion");
    //Add a new signature to the PDF page.
    PdfSignature signature = new PdfSignature(document, page, pdfCert, "Signature");
    signature.Bounds = new RectangleF(10, 20, 400, 200);
    //Sets the estimated size of the signature.
    signature.EstimatedSignatureSize = 20000;
    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
