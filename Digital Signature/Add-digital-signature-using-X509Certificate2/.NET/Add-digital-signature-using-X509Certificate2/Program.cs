using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Security;
using System.Security.Cryptography.X509Certificates;

//Creates a new PDF document.
using (PdfDocument document = new PdfDocument())
{

    //Adds a new page.
    PdfPage page = document.Pages.Add();

    //Create graphics for the page. 
    PdfGraphics graphics = page.Graphics;

    //Creates a certificate instance from PFX file with private key.
    X509Certificate2 certificate = new X509Certificate2(Path.GetFullPath(@"Data/PDF.pfx"), "syncfusion");
    PdfCertificate pdfCertificate = new PdfCertificate(certificate);

    //Creates a digital signature.
    PdfSignature signature = new PdfSignature(document, page, pdfCertificate, "Signature");

    //Sets an image for signature field.
    FileStream imageStream = new FileStream(Path.GetFullPath(@"Data/signature.png"), FileMode.Open, FileAccess.Read);
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
