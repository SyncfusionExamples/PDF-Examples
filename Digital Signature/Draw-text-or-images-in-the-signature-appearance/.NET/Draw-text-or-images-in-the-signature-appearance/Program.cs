using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Security;

//Create a new pdf document.
using (PdfDocument document = new PdfDocument())
{
    //Add a new page.
    PdfPageBase page = document.Pages.Add();
    //Create graphics for the page. 
    PdfGraphics graphics = page.Graphics;
    //Create a certificate instance from a PFX file with a private key.
    FileStream certificateStream = new FileStream(Path.GetFullPath(@"Data/PDF.pfx"), FileMode.Open, FileAccess.Read);
    PdfCertificate pdfCert = new PdfCertificate(certificateStream, "syncfusion");
    //Create a digital signature.
    PdfSignature signature = new PdfSignature(document, page, pdfCert, "Signature");
    //Set an image for signature field.
    FileStream imageStream = new FileStream(Path.GetFullPath(@"Data/signature.png"), FileMode.Open, FileAccess.Read);
    //Set an image for signature field.
    PdfBitmap signatureImage = new PdfBitmap(imageStream);
    //Set the signature information.
    signature.Bounds = new RectangleF(new PointF(0, 0), signatureImage.PhysicalDimension);
    signature.ContactInfo = "johndoe@owned.us";
    signature.LocationInfo = "Honolulu, Hawaii";
    signature.Reason = "I am author of this document.";
    //Create appearance for the digital signature.
    signature.Appearance.Normal.Graphics.DrawImage(signatureImage, signature.Bounds);
    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}