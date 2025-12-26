using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Security;

//Creates a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a new page.
    PdfPageBase page = document.Pages.Add();
    PdfGraphics graphics = page.Graphics;
    //Get the certificate file.
    Org.BouncyCastle.X509.X509CertificateParser cp = new Org.BouncyCastle.X509.X509CertificateParser();
    Org.BouncyCastle.X509.X509Certificate cert = cp.ReadCertificate(File.ReadAllBytes(Path.GetFullPath(@"Data/certificate.cer")));
    //Read the PEM file.
    PemReader pmr = new PemReader(new StringReader(File.ReadAllText(Path.GetFullPath(@"Data/privateKey.pem"))));
    AsymmetricCipherKeyPair KeyPair = (AsymmetricCipherKeyPair)pmr.ReadObject();
    //Get the PFX file stream. 
    Stream pfxFile = CreatePfxFile(cert, KeyPair.Private);
    //Creates a certificate instance from the PFX file with a private key.
    PdfCertificate pdfCert = new PdfCertificate(pfxFile, "syncfusion");
    //Creates a digital signature.
    PdfSignature signature = new PdfSignature(document, page, pdfCert, "Signature");
    //Sets the signature information.
    signature.Bounds = new RectangleF(new PointF(0, 0), new SizeF(300, 100));
    signature.ContactInfo = "johndoe@owned.us";
    signature.LocationInfo = "Honolulu, Hawaii";
    signature.Reason = "I am author of this document.";
    FileStream imageStream = new FileStream(Path.GetFullPath(@"Data/Logo.png"), FileMode.Open, FileAccess.Read);
    //Load an image file.
    PdfBitmap image = new PdfBitmap(imageStream);
    //Draw an image in the signature appearance.
    signature.Appearance.Normal.Graphics.DrawImage(image, new RectangleF(0, 0, 300, 100));
    //Saves the document.
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

// Create a PFX file using the BouncyCastle.
 static Stream CreatePfxFile(Org.BouncyCastle.X509.X509Certificate certificate, AsymmetricKeyParameter privateKey)
{
    //Create a certificate entry.
    X509CertificateEntry certEntry = new X509CertificateEntry(certificate);
    string friendlyName = certificate.SubjectDN.ToString();
    //Get bytes of the private key.
    PrivateKeyInfo keyInfo = PrivateKeyInfoFactory.CreatePrivateKeyInfo(privateKey);
    byte[] keyBytes = keyInfo.ToAsn1Object().GetEncoded();
    Pkcs12StoreBuilder builder = new Pkcs12StoreBuilder();
    builder.SetUseDerEncoding(true);
    Pkcs12Store store = builder.Build();
    //Create a store entry.
    store.SetKeyEntry("private", new AsymmetricKeyEntry(privateKey), new X509CertificateEntry[] { certEntry });
    //Save the story to the stream.
    MemoryStream stream = new MemoryStream();
    store.Save(stream, "syncfusion".ToCharArray(), new SecureRandom());
    return stream;
}