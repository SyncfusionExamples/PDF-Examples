// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;

//Get the stream from the document.
FileStream documentStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read);

//Load an existing PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(documentStream);

//Gets the first signature field of the PDF document
PdfLoadedSignatureField signatureField = loadedDocument.Form.Fields[0] as PdfLoadedSignatureField;
PdfSignature signature = signatureField.Signature;

//Create X509Certificate2 from your certificate to create a long-term validity.
X509Certificate2 x509 = new X509Certificate2(Path.GetFullPath(@"Data/PDF.pfx"), "syncfusion");

//Create LTV with your public certificates.
signature.CreateLongTermValidity(new List<X509Certificate2> { x509 });

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
