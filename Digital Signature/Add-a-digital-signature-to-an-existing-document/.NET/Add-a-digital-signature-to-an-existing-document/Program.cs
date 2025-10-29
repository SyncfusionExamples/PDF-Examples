using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;

//Load the PDF document
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(@"Data/Input.pdf"))
{
    // Gets the first page of the document
    PdfPageBase page = loadedDocument.Pages[0];
    // Load the certificate from a PFX file with a private key
    PdfCertificate pdfCert = new PdfCertificate(Path.GetFullPath(@"Data/PDF.pfx"), "syncfusion");
    // Create a signature
    PdfSignature signature = new PdfSignature(loadedDocument, page, pdfCert, "Signature");
    // Set signature information
    signature.Bounds = new RectangleF(227.6355f, 675.795044f, 150.57901f, 32.58f);
    signature.SignedName = "Syncfusion";
    signature.ContactInfo = "johndoe@owned.us";
    signature.LocationInfo = "Honolulu, Hawaii";
    signature.Reason = "I am the author of this document.";
    // Load the image for the signature field
    using FileStream imageStream = new FileStream(Path.GetFullPath(@"Data/signature.png"), FileMode.Open, FileAccess.Read);
    PdfBitmap signatureImage = new PdfBitmap(imageStream);
    // Draw the image on the signature field
    signature.Appearance.Normal.Graphics.DrawImage(signatureImage, new RectangleF(0, 0, signature.Bounds.Width, signature.Bounds.Height));
    // Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}