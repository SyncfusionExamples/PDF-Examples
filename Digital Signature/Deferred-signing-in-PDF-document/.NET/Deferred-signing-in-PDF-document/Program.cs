// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

class Program
{
    public static string PublicCert = "MIIDFTCCAf2gAwIBAgIQMjdwZGujtplDiSGarQzO1DANBgkqhkiG9w0BAQsFADAXMRUwEwYDVQQDEwxUZXN0Q2VydFJvb3QwHhcNMTkwOTA5MDg0MzM5WhcNMzkxMjMxMjM1OTU5WjAXMRUwEwYDVQQDEwxUZXN0Q2VydFJvb3QwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCWs+BZKfWf5cZauYDpXPlHUZour4oNaGoAfySXUD28KLNxCI6AWlK+UV+JJWgcrJ9SpLuoxQb1384gZhQMe4RFtILQpxx9nAxtwsd7/6OLI4G9TRIdy6PJ2OHyHKL9ZqI/+XkUbgznUF9o0F2VlQwszSCQREDQ5PxcGy/GWS71ZT1tvs8iqMVi3PCUH8ERwqTwIhWvRt6weVZ/daR9rNqkEPkpT5tQPMGvmqEinxbjpO8h8gU91rXbiHaY7QlDgCmEy3zWVIROR56x3ZJv5/xjJ/ya4X51P3DcLNGgUTRre0cYXHfnyTQAVFDGxEGsTd4xOnMWrbMaoeRBt8dtBGNBAgMBAAGjXTBbMA8GA1UdEwEB/wQFMAMBAf8wSAYDVR0BBEEwP4AQk/aIkhJaRQ2nRg1ECf13f6EZMBcxFTATBgNVBAMTDFRlc3RDZXJ0Um9vdIIQMjdwZGujtplDiSGarQzO1DANBgkqhkiG9w0BAQsFAAOCAQEAbcFInTXT+08eV1JyrkMsR3HZGtPXyAGRSiZkMJJKE1MU79fFXCiQf6/UpCV76vdCCSOrZLJweUeZPLznZhOxu9aEGnA0CPEcphYUVT9J8aV8MpQJu5DKGbphdBuZNlBQvVg9Yxs0T7Ne49S3s2EUL/w6tFoBuGh1ar9rc3IRmJA8WM2orz4Q8bVhYdtlxWynfx3idCv7pQDymHmB0Wt5iSlcAfcDrZb7YSq+VYIHzAZatefjGRSsbRuVpSfz3dt+cVttKbY3mOWD4zaUvPvKs6bWznxStEBHomcWd3DymekC78aI9XKLmetddpzx6eOgf9Vju8KuO+udGDpoPy2apw==";
    public static byte[] SignedHash = null;
    public static byte[] SignedHash2 = null;

    static void Main(string[] args)
    {
        CreateEmptySignedPDF();
        DeferredSign();
    }

    static void CreateEmptySignedPDF()
    {
        // Get the stream from the document.
        FileStream documentStream = new FileStream(Path.GetFullPath("../../../Barcode.pdf"), FileMode.Open, FileAccess.Read);

        //Load an existing PDF document.
        PdfLoadedDocument loadedDocument = new PdfLoadedDocument(documentStream);

        //Creates a digital signature.
        PdfSignature signature = new PdfSignature(loadedDocument, loadedDocument.Pages[0], null, "Signature");

        //Sets the signature information.
        signature.Bounds = new RectangleF(new PointF(0, 0), new SizeF(100, 30));
        signature.Settings.CryptographicStandard = CryptographicStandard.CADES;
        signature.Settings.DigestAlgorithm = DigestAlgorithm.SHA1;

        //Create an external signer.
        IPdfExternalSigner externalSignature = new SignEmpty("SHA1");

        //Add public certificates.
        System.Collections.Generic.List<X509Certificate2> certificates = new System.Collections.Generic.List<X509Certificate2>();
        certificates.Add(new X509Certificate2(Convert.FromBase64String(PublicCert)));
        signature.AddExternalSigner(externalSignature, certificates, null);

        //Save the document.
        FileStream inputFileStream = new FileStream(Path.GetFullPath("../../../EmptySignature.pdf"), FileMode.Create, FileAccess.ReadWrite);
        loadedDocument.Save(inputFileStream);

        //Close the PDF document.
        loadedDocument.Close(true);
        inputFileStream.Close();
    }

    static void DeferredSign()
    {
        //Create an external signer with a signed hash message.
        IPdfExternalSigner externalSigner = new ExternalSigner("SHA1", Program.SignedHash);

        //Add public certificates.
        System.Collections.Generic.List<X509Certificate2> publicCertificates = new System.Collections.Generic.List<X509Certificate2>();
        publicCertificates.Add(new X509Certificate2(Convert.FromBase64String(PublicCert)));

        //Create an output file stream.
        FileStream outputFileStream = new FileStream(Path.GetFullPath("../../../DeferredSign.pdf"), FileMode.Create, FileAccess.ReadWrite);

        // Get the stream from the document
        FileStream inputFileStream = new FileStream(Path.GetFullPath("../../../EmptySignature.pdf"), FileMode.Open, FileAccess.Read);

        string pdfPassword = string.Empty;

        //Replace an empty signature.
        PdfSignature.ReplaceEmptySignature(inputFileStream, pdfPassword, outputFileStream, "Signature", externalSigner, publicCertificates);

        outputFileStream.Close();
    }

    /// <summary>
    /// Represents to sign an empty signature from the external signer.
    /// </summary>
    class SignEmpty : IPdfExternalSigner
    {
        private string _hashAlgorithm;

        public string HashAlgorithm
        {
            get { return _hashAlgorithm; }
        }

        public SignEmpty(string hashAlgorithm)
        {
            _hashAlgorithm = hashAlgorithm;
        }

        public byte[] Sign(byte[] message, out byte[] timeStampResponse)
        {
            //Send document hash for signing using the external services.
            SignDocumentHash(message);
            //Set a null value to create an empty signed document.
            byte[] signedBytes = null;
            timeStampResponse = null;
            return signedBytes;
        }
        //Example for signed docuement hash 
        private void SignDocumentHash(byte[] documentHash)
        {
            X509Certificate2 digitalID = new X509Certificate2(new X509Certificate2(Path.GetFullPath("../../../PDF.pfx"), "password123"));
            if (digitalID.PrivateKey is System.Security.Cryptography.RSACryptoServiceProvider)
            {
                System.Security.Cryptography.RSACryptoServiceProvider rsa = (System.Security.Cryptography.RSACryptoServiceProvider)digitalID.PrivateKey;
                Program.SignedHash = rsa.SignData(documentHash, HashAlgorithm);
            }
            else if (digitalID.PrivateKey is RSACng)
            {
                RSACng rsa = (RSACng)digitalID.PrivateKey;
                Program.SignedHash = rsa.SignData(documentHash, System.Security.Cryptography.HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
            }
        }
    }
    /// <summary>
    /// Represents to replace an empty signature from an external signer.
    /// </summary>
    class ExternalSigner : IPdfExternalSigner
    {
        private string _hashAlgorithm;
        private byte[] _signedHash;
        public string HashAlgorithm
        {
            get { return _hashAlgorithm; }
        }

        public ExternalSigner(string hashAlgorithm, byte[] hash)
        {
            _hashAlgorithm = hashAlgorithm;
            _signedHash = hash;
        }

        public byte[] Sign(byte[] message, out byte[] timeStampResponse)
        {
            //Set the signed hash message to replace an empty signature.
            byte[] signedBytes = _signedHash;
            timeStampResponse = null;
            return signedBytes;
        }
    }
}
