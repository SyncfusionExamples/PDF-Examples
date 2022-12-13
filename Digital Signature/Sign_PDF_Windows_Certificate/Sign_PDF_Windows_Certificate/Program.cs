//Load existing PDF document.
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using Syncfusion.Pdf;
using System.Security.Cryptography.X509Certificates;

//Initialize the Windows store.
X509Store store = new X509Store("MY", StoreLocation.CurrentUser);
store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
//Find the certificate using thumb print.
X509Certificate2Collection fcollection = (X509Certificate2Collection)collection.Find(X509FindType.FindByThumbprint, "F85E1C5D93115CA3F969DA3ABC8E0E9547FCCF5A", true);
X509Certificate2 digitalID = fcollection[0];

//Load existing PDF document.
FileStream documentStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(documentStream);
//Load X509Certificate2.
PdfCertificate certificate = new PdfCertificate(digitalID);

//Create a Revision 2 signature with loaded digital ID.
PdfSignature signature = new PdfSignature(loadedDocument, loadedDocument.Pages[0], certificate, "DigitalSignature");
//Changing the digital signature standard and hashing algorithm.
signature.Settings.CryptographicStandard = CryptographicStandard.CADES;
signature.Settings.DigestAlgorithm = DigestAlgorithm.SHA512;

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
