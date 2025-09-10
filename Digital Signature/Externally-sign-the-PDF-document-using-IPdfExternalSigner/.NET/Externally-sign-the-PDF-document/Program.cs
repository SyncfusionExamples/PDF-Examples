using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using Syncfusion.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

namespace Externally_sign_the_PDF_document
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Get the stream from the document
            FileStream documentStream = new FileStream(Path.GetFullPath(@"../../../Data/Barcode.pdf"), FileMode.Open, FileAccess.Read);

            // Load the existing PDF document
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(documentStream);

            // Create a digital signature
            PdfSignature signature = new PdfSignature(loadedDocument, loadedDocument.Pages[0], null, "Signature");

            // Set the signature information
            signature.Bounds = new RectangleF(new PointF(0, 0), new SizeF(100, 30));
            signature.Settings.CryptographicStandard = CryptographicStandard.CADES;
            signature.Settings.DigestAlgorithm = DigestAlgorithm.SHA1;

            // Create an external signer
            IPdfExternalSigner externalSignature = new ExternalSigner("SHA1");

            // Add public certificates
            List<X509Certificate2> certificates = new List<X509Certificate2>();
            certificates.Add(new X509Certificate2(Path.GetFullPath(@"../../../Data/PDF.pfx"), "password123"));
            signature.AddExternalSigner(externalSignature, certificates, null);

            // Create file stream
            using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
            {
                // Save the PDF document to file stream
                loadedDocument.Save(outputFileStream);
            }

            // Close the document
            loadedDocument.Close(true);
        }

        // Create the external signer class and sign the document hash
        class ExternalSigner : IPdfExternalSigner
        {
            private string _hashAlgorithm;

            public string HashAlgorithm
            {
                get { return _hashAlgorithm; }
            }

            public ExternalSigner(string hashAlgorithm)
            {
                _hashAlgorithm = hashAlgorithm;
            }

            public byte[] Sign(byte[] message, out byte[] timeStampResponse)
            {
                timeStampResponse = null;
                X509Certificate2 digitalID = new X509Certificate2(Path.GetFullPath(@"../../../Data/PDF.pfx"), "password123");

                if (digitalID.PrivateKey is RSACryptoServiceProvider rsaProvider)
                {
                    return rsaProvider.SignData(message, HashAlgorithm);
                }
                else if (digitalID.PrivateKey is RSACng rsaCng)
                {
                    return rsaCng.SignData(message, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
                }
                else if (digitalID.PrivateKey is RSAOpenSsl rsaOpenSsl)
                {
                    return rsaOpenSsl.SignData(message, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
                }

                return null;
            }
        }
    }
}
