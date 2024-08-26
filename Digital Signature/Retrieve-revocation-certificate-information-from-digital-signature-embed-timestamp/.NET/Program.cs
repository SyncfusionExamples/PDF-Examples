// See https://aka.ms/new-console-template for more information
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using System.Security.Cryptography.X509Certificates;

//Load a PDF document
FileStream docStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read);
PdfLoadedDocument document = new PdfLoadedDocument(docStream);
//Gets the signature field.
PdfLoadedSignatureField signatureField = document.Form.Fields[0] as PdfLoadedSignatureField;
//Validates signature and gets the validation result.
PdfSignatureValidationResult result = signatureField.ValidateSignature();
//Gets signer certificates
PdfSignerCertificate[] certifcate = result.TimeStampInformation.SignerCertificates;
//Print the certifcate value
foreach (PdfSignerCertificate signerCertificate in certifcate)
{
    if (signerCertificate.OcspCertificate != null)
    {
        Console.WriteLine("------------OCSP Certificate-------------");
        Console.WriteLine();
        foreach (X509Certificate2 item in signerCertificate.OcspCertificate.Certificates)
        {
            Console.WriteLine("The OCSP Response was signed by " + item.SubjectName.Name);
        }
        Console.WriteLine("Is Embedded: " + signerCertificate.OcspCertificate.IsEmbedded);
        Console.WriteLine("ValidFrom: " + signerCertificate.OcspCertificate.ValidFrom);
        Console.WriteLine("ValidTo: " + signerCertificate.OcspCertificate.ValidTo);
        Console.WriteLine();
        continue;
    }
    if (signerCertificate.CrlCertificate != null)
    {
        Console.WriteLine("------------CRL Certificate--------------");
        Console.WriteLine();
        foreach (X509Certificate2 item in signerCertificate.CrlCertificate.Certificates)
        {
            if (item != null)
            {
                Console.WriteLine("The CRL was signed by " + item.SubjectName.Name);
            }
        }
        Console.WriteLine("Is Embedded: " + signerCertificate.CrlCertificate.IsEmbedded);
        Console.WriteLine("ValidFrom: " + signerCertificate.CrlCertificate.ValidFrom);
        Console.WriteLine("ValidTo: " + signerCertificate.CrlCertificate.ValidTo);
        break;
    }
}
//Close the document.
document.Close(true);
