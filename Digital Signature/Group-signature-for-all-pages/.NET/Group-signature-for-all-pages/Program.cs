using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;

// Load the PDF document
using (PdfLoadedDocument document = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Ensure the form (AcroForm) exists before adding signature fields
    if (document.Form == null)
        document.CreateForm();
    // Turn off automatic field naming if you want full control over field names
    document.Form.FieldAutoNaming = false;
    // Create certificate from PFX file
    PdfCertificate pdfCert = new PdfCertificate(Path.GetFullPath(@"Data/PDF.pfx"), "syncfusion");
    // Load the signature image once 
    using FileStream imageStream = new FileStream(Path.GetFullPath(@"Data/Signature.png"), FileMode.Open, FileAccess.Read);
    PdfBitmap signatureImage = new PdfBitmap(imageStream);
    // use this flag. Set to 'false' to draw for each signature field
    bool appearanceApplied = false;
    // Iterate pages and add a signature field to each page
    for (int i = 0; i < document.Pages.Count; i++)
    {
        // Get current page
        PdfPageBase page = document.Pages[i];
        // Create a signature field on the page using the certificate
        PdfSignature signature = new PdfSignature(document, page, pdfCert, "Signature");
        // Position & size of the signature field
        signature.Bounds = new RectangleF(new PointF(10, 10), new SizeF(100, 60));
        // Optional metadata shown in the signature properties
        signature.ContactInfo = "johndoe@owned.us";
        signature.LocationInfo = "Honolulu, Hawaii";
        signature.Reason = "I am author of this document.";
        // Draw the signature image into the signature appearance once
        if (!appearanceApplied)
        {
            signature.Appearance.Normal.Graphics.DrawImage(
                signatureImage,
                0, 0,
                signature.Bounds.Width,
                signature.Bounds.Height
            );
            appearanceApplied = true;
        }
    }
    // Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
