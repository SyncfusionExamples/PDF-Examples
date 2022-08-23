// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Security;
using System.Security.Cryptography.X509Certificates;

//Creates a new PDF document.
PdfDocument document = new PdfDocument();

//Adds a new page.
PdfPage page = document.Pages.Add();

//Create graphics for the page. 
PdfGraphics graphics = page.Graphics;

//Creates a certificate instance from PFX file with private key.
X509Certificate2 certificate = new X509Certificate2(Path.GetFullPath("../../../PDF.pfx"), "syncfusion");
PdfCertificate pdfCertificate = new PdfCertificate(certificate);

//Creates a digital signature.
PdfSignature signature = new PdfSignature(document, page, pdfCertificate, "Signature");

//Sets an image for signature field.
FileStream imageStream = new FileStream(Path.GetFullPath("../../../signature.png"), FileMode.Open, FileAccess.Read);
PdfBitmap signatureImage = new PdfBitmap(imageStream);

//Sets signature information.
signature.Bounds = new RectangleF(new PointF(0, 0), signatureImage.PhysicalDimension);
signature.ContactInfo = "johndoe@owned.us";
signature.LocationInfo = "Honolulu, Hawaii";
signature.Reason = "I am author of this document.";

//Draws the signature image.
graphics.DrawImage(signatureImage, 0, 0);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);