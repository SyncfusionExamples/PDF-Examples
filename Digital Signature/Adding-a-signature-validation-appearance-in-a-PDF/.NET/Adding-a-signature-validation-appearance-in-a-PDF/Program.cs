// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Security;

//Creates a new PDF document.
PdfDocument document = new PdfDocument();

//Adds a new page.
PdfPageBase page = document.Pages.Add();

//Create graphics for the page. 
PdfGraphics graphics = page.Graphics;

//Creates a certificate instance from the PFX file with private key.
FileStream certificateStream = new FileStream(Path.GetFullPath("../../../PDF.pfx"), FileMode.Open, FileAccess.Read);
PdfCertificate pdfCert = new PdfCertificate(certificateStream, "syncfusion");

//Creates a digital signature.
PdfSignature signature = new PdfSignature(document, page, pdfCert, "Signature");

//Sets an image for the signature field.
FileStream imageStream = new FileStream(Path.GetFullPath("../../../signature.png"), FileMode.Open, FileAccess.Read);

//Sets an image for signature field.
PdfBitmap signatureImage = new PdfBitmap(imageStream);

//Sets enable signature validation appearance.
signature.EnableValidationAppearance = true;

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