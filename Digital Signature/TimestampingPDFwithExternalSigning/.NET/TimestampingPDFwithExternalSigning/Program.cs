using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using Syncfusion.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using Org.BouncyCastle.Tsp;
using System.Net;
using System.Text;
using Org.BouncyCastle.Math;

namespace Externally_sign_the_PDF_document
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Get the stream from the document
            FileStream documentStream = new FileStream(Path.GetFullPath(@"Data/Barcode.pdf"), FileMode.Open, FileAccess.Read);
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
            certificates.Add(new X509Certificate2(new X509Certificate2(Path.GetFullPath(@"Data/PDF.pfx"), "password123")));
            signature.AddExternalSigner(externalSignature, certificates, null);

            //Create file stream.
            using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
            {
                //Save the PDF document to file stream.
                loadedDocument.Save(outputFileStream);
            }
            //Close the document.
            loadedDocument.Close(true);
        }
        //Create the external signer class and sign the document hash.
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
                byte[] signedBytes = null;
                X509Certificate2 digitalID = new X509Certificate2(new X509Certificate2(Path.GetFullPath(@"Data/PDF.pfx"), "password123"));
                if (digitalID.PrivateKey is System.Security.Cryptography.RSACryptoServiceProvider)
                {
                    System.Security.Cryptography.RSACryptoServiceProvider rsa = (System.Security.Cryptography.RSACryptoServiceProvider)digitalID.PrivateKey;
                    signedBytes = rsa.SignData(message, HashAlgorithm);
                }
                else if (digitalID.PrivateKey is RSACng)
                {
                    RSACng rsa = (RSACng)digitalID.PrivateKey;
                    signedBytes = rsa.SignData(message, System.Security.Cryptography.HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
                }
                timeStampResponse = GetRFC3161TimeStampToken(signedBytes);

                return signedBytes;
            }
            public byte[] GetRFC3161TimeStampToken(byte[] bytes)
            {
                SHA1 sha1 = SHA1CryptoServiceProvider.Create();
                byte[] hash = sha1.ComputeHash(bytes);
                TimeStampRequestGenerator reqGen = new TimeStampRequestGenerator();
                reqGen.SetCertReq(true);
                TimeStampRequest tsReq = reqGen.Generate(TspAlgorithms.Sha1, hash, BigInteger.ValueOf(100));
                byte[] tsData = tsReq.GetEncoded();
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://rfc3161.ai.moda"); // Update your timestamp Uri here
                req.Method = "POST";
                req.ContentType = "application/timestamp-query";
                req.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes("9024:yourPass")));
                req.ContentLength = tsData.Length;
                Stream reqStream = req.GetRequestStream();
                reqStream.Write(tsData, 0, tsData.Length);
                reqStream.Close();
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                if (res != null)
                {
                    Stream resStream = new BufferedStream(res.GetResponseStream());
                    TimeStampResponse tsRes = new TimeStampResponse(resStream);
                    return tsRes.TimeStampToken.GetEncoded();
                }
                return null;
            }
        }
    }
}