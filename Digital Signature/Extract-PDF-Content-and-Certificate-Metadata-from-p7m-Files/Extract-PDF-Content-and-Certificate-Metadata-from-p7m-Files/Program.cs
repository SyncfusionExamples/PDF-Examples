using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Load the signed CMS (assumes signedCmsBytes contains the Signed CMS data)
            byte[] signedCmsBytes = File.ReadAllBytes(Path.GetFullPath(@"Data/TestCert.pdf.p7s"));

            SignedCms signedCms = new SignedCms();

            // Decode the Signed CMS data
            signedCms.Decode(signedCmsBytes);

            // Verify the signature without considering the certificate chain
            signedCms.CheckSignature(true);

            // Extract the original content
            byte[] originalMessage = signedCms.ContentInfo.Content;

            // Extract signer information
            foreach (SignerInfo signerInfo in signedCms.SignerInfos)
            {
                // Get the signing certificate
                X509Certificate2 signerCertificate = signerInfo.Certificate;

                // Extract signer's name
                string signerName = signerCertificate?.Subject ?? "Unknown Signer";
                Console.WriteLine($"Signer Name: {signerName}");

                // Extract signing date (signing time attribute)
                Pkcs9SigningTime signingTime = null;
                foreach (var data in from CryptographicAttributeObject attr in signerInfo.SignedAttributes
                                     from AsnEncodedData data in attr.Values
                                     where data is Pkcs9SigningTime
                                     select data)
                {
                    signingTime = (Pkcs9SigningTime)data;
                    break;
                }

                if (signingTime != null)
                {
                    Console.WriteLine($"Signing Time: {signingTime.SigningTime}");
                }
                else
                {
                    Console.WriteLine("Signing Time: Not available in the attributes.");
                }
            }
        }
    }

}
