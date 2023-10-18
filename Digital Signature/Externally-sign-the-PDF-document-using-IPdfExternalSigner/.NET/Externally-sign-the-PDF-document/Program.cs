using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using Syncfusion.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

namespace Externally_sign_the_PDF_document {
    internal class Program {
        public static string PublicCert = "MIIDFTCCAf2gAwIBAgIQMjdwZGujtplDiSGarQzO1DANBgkqhkiG9w0BAQsFADAXMRUwEwYDVQQDEwxUZXN0Q2VydFJvb3QwHhcNMTkwOTA5MDg0MzM5WhcNMzkxMjMxMjM1OTU5WjAXMRUwEwYDVQQDEwxUZXN0Q2VydFJvb3QwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCWs+BZKfWf5cZauYDpXPlHUZour4oNaGoAfySXUD28KLNxCI6AWlK+UV+JJWgcrJ9SpLuoxQb1384gZhQMe4RFtILQpxx9nAxtwsd7/6OLI4G9TRIdy6PJ2OHyHKL9ZqI/+XkUbgznUF9o0F2VlQwszSCQREDQ5PxcGy/GWS71ZT1tvs8iqMVi3PCUH8ERwqTwIhWvRt6weVZ/daR9rNqkEPkpT5tQPMGvmqEinxbjpO8h8gU91rXbiHaY7QlDgCmEy3zWVIROR56x3ZJv5/xjJ/ya4X51P3DcLNGgUTRre0cYXHfnyTQAVFDGxEGsTd4xOnMWrbMaoeRBt8dtBGNBAgMBAAGjXTBbMA8GA1UdEwEB/wQFMAMBAf8wSAYDVR0BBEEwP4AQk/aIkhJaRQ2nRg1ECf13f6EZMBcxFTATBgNVBAMTDFRlc3RDZXJ0Um9vdIIQMjdwZGujtplDiSGarQzO1DANBgkqhkiG9w0BAQsFAAOCAQEAbcFInTXT+08eV1JyrkMsR3HZGtPXyAGRSiZkMJJKE1MU79fFXCiQf6/UpCV76vdCCSOrZLJweUeZPLznZhOxu9aEGnA0CPEcphYUVT9J8aV8MpQJu5DKGbphdBuZNlBQvVg9Yxs0T7Ne49S3s2EUL/w6tFoBuGh1ar9rc3IRmJA8WM2orz4Q8bVhYdtlxWynfx3idCv7pQDymHmB0Wt5iSlcAfcDrZb7YSq+VYIHzAZatefjGRSsbRuVpSfz3dt+cVttKbY3mOWD4zaUvPvKs6bWznxStEBHomcWd3DymekC78aI9XKLmetddpzx6eOgf9Vju8KuO+udGDpoPy2apw==";
        static void Main(string[] args) {
            //Get the stream from the document
            FileStream documentStream = new FileStream(Path.GetFullPath("../../../Barcode.pdf"), FileMode.Open, FileAccess.Read);
            //Load the existing PDF document
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(documentStream);

            //Creates a digital signature.
            PdfSignature signature = new PdfSignature(loadedDocument, loadedDocument.Pages[0], null, "Signature");
            //Sets the signature information.
            signature.Bounds = new RectangleF(new PointF(0, 0), new SizeF(100, 30));
            signature.Settings.CryptographicStandard = CryptographicStandard.CADES;
            signature.Settings.DigestAlgorithm = DigestAlgorithm.SHA1;

            //Create an external signer.
            IPdfExternalSigner externalSignature = new ExternalSigner("SHA1");

            //Add public certificates.
            List<X509Certificate2> certificates = new List<X509Certificate2>();
            certificates.Add(new X509Certificate2(Convert.FromBase64String(PublicCert)));
            signature.AddExternalSigner(externalSignature, certificates, null);

            //Create file stream.
            using (FileStream outputFileStream = new FileStream("Output.pdf", FileMode.Create, FileAccess.ReadWrite)) {
                //Save the PDF document to file stream.
                loadedDocument.Save(outputFileStream);
            }
            //Close the document.
            loadedDocument.Close(true);
        }
        //Create the external signer class and sign the document hash.
        class ExternalSigner : IPdfExternalSigner {
            private string _hashAlgorithm;
            public string HashAlgorithm {
                get { return _hashAlgorithm; }
            }

            public ExternalSigner(string hashAlgorithm) {
                _hashAlgorithm = hashAlgorithm;
            }
            public byte[] Sign(byte[] message, out byte[] timeStampResponse) {
                timeStampResponse = null;
                X509Certificate2 digitalID = new X509Certificate2(new X509Certificate2(Path.GetFullPath("../../../PDF.pfx"), "password123"));
                if (digitalID.PrivateKey is System.Security.Cryptography.RSACryptoServiceProvider) {
                    System.Security.Cryptography.RSACryptoServiceProvider rsa = (System.Security.Cryptography.RSACryptoServiceProvider)digitalID.PrivateKey;
                    return rsa.SignData(message, HashAlgorithm);
                }
                else if (digitalID.PrivateKey is RSACng) {
                    RSACng rsa = (RSACng)digitalID.PrivateKey;
                    return rsa.SignData(message, System.Security.Cryptography.HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
                }
                return null;
            }
        }
    }
}