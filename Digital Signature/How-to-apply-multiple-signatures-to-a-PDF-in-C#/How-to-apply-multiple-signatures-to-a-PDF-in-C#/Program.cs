using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;

namespace Create_PDF
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Register your Syncfusion License Key.
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Your License Key");
            //Load the PDF and call the SignPDF method.
            FileStream fileStream = new FileStream("Data/Input.pdf", FileMode.Open, FileAccess.ReadWrite);
            MemoryStream outputStream = SignPDF(fileStream, "signature1", 0);
            //Call the SignPDF method again for second signer
            MemoryStream outputStream1 = SignPDF(outputStream, "signature2", 1);
            //Save the final multi signed PDF document
            File.WriteAllBytes(@"SignedDocument.pdf", outputStream1.ToArray());
        }

        public static MemoryStream SignPDF(Stream inputStream, string signatureName, int pageIndex)
        {
            // Load the PDF document from the input stream
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputStream);

            // Get the specified page
            PdfLoadedPage page = loadedDocument.Pages[pageIndex] as PdfLoadedPage;

            // Load the certificate
            FileStream certificateStream = new FileStream(Path.GetFullPath(@"Data/PDF.pfx"), FileMode.Open, FileAccess.Read);
            PdfCertificate certificate = new PdfCertificate(certificateStream, "syncfusion");

            // Create the signature
            PdfSignature signature = new PdfSignature(loadedDocument, page, certificate, signatureName);
            signature.Bounds = new Syncfusion.Drawing.RectangleF(400, 740, 90, 20);

            // Choose the image based on the signature name
            string imagePath = signatureName == "signature1"
                ? @"Data/Student Signature.jpg"
                : @"Data/Teacher Signature.png";

            FileStream imageStream = new FileStream(Path.GetFullPath(imagePath), FileMode.Open, FileAccess.Read);
            PdfBitmap signatureImage = new PdfBitmap(imageStream);

            // Draw the image in the signature appearance
            signature.Appearance.Normal.Graphics.DrawImage(signatureImage, 0, 0, 90, 20);

            // Save the signed document to a memory stream
            MemoryStream outputStream = new MemoryStream();
            loadedDocument.Save(outputStream);
            loadedDocument.Close(true);
            outputStream.Position = 0; // Reset stream position for next use
            return outputStream;
        }

    }
}