// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Security;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a new page.
PdfPageBase page = document.Pages.Add();

//Create graphics for the page. 
PdfGraphics graphics = page.Graphics;

//Create a certificate instance from a PFX file with a private key.
FileStream certificateStream = new FileStream(Path.GetFullPath("../../../PDF.pfx"), FileMode.Open, FileAccess.Read);
PdfCertificate pdfCert = new PdfCertificate(certificateStream, "syncfusion");

//Create a digital signature.
PdfSignature signature = new PdfSignature(document, page, pdfCert, "Signature");

//Set an image for signature field.
FileStream imageStream = new FileStream(Path.GetFullPath("../../../signature.png"), FileMode.Open, FileAccess.Read);

//Set an image for signature field.
PdfBitmap signatureImage = new PdfBitmap(imageStream);

//Set the signature information.
signature.Bounds = new RectangleF(new PointF(0, 0), signatureImage.PhysicalDimension);
signature.ContactInfo = "johndoe@owned.us";
signature.LocationInfo = "Honolulu, Hawaii";
signature.Reason = "I am author of this document.";

//Create appearance for the digital signature.
signature.Appearance.Normal.Graphics.DrawImage(signatureImage, signature.Bounds);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);


