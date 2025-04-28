// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;

//Open existing PDF document as stream
using (FileStream inputStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
{
    // Load the existing PDF document
    PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputStream);

    // Gets the first page of the document
    PdfPageBase page = loadedDocument.Pages[0];

    // Load the certificate from a PFX file with a private key
    FileStream certificateStream = new FileStream(Path.GetFullPath(@"Data/PDF.pfx"), FileMode.Open, FileAccess.Read);
    PdfCertificate pdfCert = new PdfCertificate(certificateStream, "syncfusion");

    // Create a signature
    PdfSignature signature = new PdfSignature(loadedDocument, page, pdfCert, "Signature");

    // Set signature information
    signature.Bounds = new RectangleF(227.6355f, 675.795044f, 150.57901f, 32.58f);
    signature.ContactInfo = "johndoe@owned.us";
    signature.LocationInfo = "Honolulu, Hawaii";
    signature.Reason = "I am the author of this document.";

    // Load the image for the signature field
    FileStream imageStream = new FileStream(Path.GetFullPath(@"Data/signature.png"), FileMode.Open, FileAccess.Read);
    PdfBitmap signatureImage = new PdfBitmap(imageStream);

    // Draw the image on the signature field
    signature.Appearance.Normal.Graphics.DrawImage(signatureImage, new RectangleF(0, 0, signature.Bounds.Width, signature.Bounds.Height));

    // Save the document to a file stream
    using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
    {
        loadedDocument.Save(outputFileStream);
    }

    //Close the document.
    loadedDocument.Close(true);
    certificateStream.Dispose();
    imageStream.Dispose();
}