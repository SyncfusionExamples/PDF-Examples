using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Security;

//Creates a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Adds a new page.
    PdfPageBase page = document.Pages.Add();

    //Create graphics for the page. 
    PdfGraphics graphics = page.Graphics;

    //Creates a certificate instance from PFX file with private key.
    FileStream certificateStream = new FileStream(Path.GetFullPath(@"Data/PDF.pfx"), FileMode.Open, FileAccess.Read);
    PdfCertificate pdfCert = new PdfCertificate(certificateStream, "syncfusion");

    //Creates a digital signature.
    PdfSignature signature = new PdfSignature(document, page, pdfCert, "Signature");

    //Change the digital signature standard and hashing algorithm.
    signature.Settings.CryptographicStandard = CryptographicStandard.CADES;
    signature.Settings.DigestAlgorithm = DigestAlgorithm.SHA512;

    //Sets an image for signature field.
    FileStream imageStream = new FileStream(Path.GetFullPath(@"Data/syncfusion_logo.png"), FileMode.Open, FileAccess.Read);

    //Sets an image for signature field.
    PdfBitmap image = new PdfBitmap(imageStream);

    //Adds time stamp by using the server URI and credentials.
    signature.TimeStampServer = new TimeStampServer(new Uri("http://time.certum.pl/"));

    //Sets signature info.
    signature.Bounds = new RectangleF(new PointF(0, 0), image.PhysicalDimension);
    signature.SignedName = "Syncfusion";
    signature.ContactInfo = "johndoe@owned.us";
    signature.LocationInfo = "Honolulu, Hawaii";
    signature.Reason = "I am author of this document.";

    //Draws the signature image.
    signature.Appearance.Normal.Graphics.DrawImage(image, 0, 0);

    // Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));

}