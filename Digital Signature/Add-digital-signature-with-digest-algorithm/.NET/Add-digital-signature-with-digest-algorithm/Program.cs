using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Security;

//Creates a new PDF document.
using (PdfDocument document = new PdfDocument())
{

    //Adds a new page.
    PdfPageBase page = document.Pages.Add();

    //Create graphics with the page. 
    PdfGraphics graphics = page.Graphics;

    //Creates a certificate instance from PFX file with private key.
    FileStream certificateStream = new FileStream(Path.GetFullPath(@"Data/PDF.pfx"), FileMode.Open, FileAccess.Read);
    PdfCertificate pdfCert = new PdfCertificate(certificateStream, "syncfusion");

    //Creates a digital signature.
    PdfSignature signature = new PdfSignature(document, page, pdfCert, "Signature");

    //Sets signature settings to customize digest algorithm specified.
    PdfSignatureSettings settings = signature.Settings;
    settings.DigestAlgorithm = DigestAlgorithm.SHA256;

    //Sets an image for signature field.
    FileStream imageStream = new FileStream(Path.GetFullPath(@"Data/signature.png"), FileMode.Open, FileAccess.Read);

    //Sets an image for signature field.
    PdfBitmap signatureImage = new PdfBitmap(imageStream);

    //Sets signature information.
    signature.Bounds = new RectangleF(new PointF(0, 0), signatureImage.PhysicalDimension);
    signature.SignedName = "Syncfusion";
    signature.ContactInfo = "johndoe@owned.us";
    signature.LocationInfo = "Honolulu, Hawaii";
    signature.Reason = "I am author of this document.";

    //Draws the signature image.
    signature.Appearance.Normal.Graphics.DrawImage(signatureImage, 0, 0);

    // Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));

}
