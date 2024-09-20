// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;

//Creates a new PDF document.
PdfDocument document = new PdfDocument();

//Adds a new page.
PdfPageBase page = document.Pages.Add();

//Create graphics for the page. 
PdfGraphics graphics = page.Graphics;

//Creates a certificate instance from PFX file with private key.
FileStream certificateStream = new FileStream(Path.GetFullPath(@"Data/PDF.pfx"), FileMode.Open, FileAccess.Read);
PdfCertificate pdfCert = new PdfCertificate(certificateStream, "DigitalPass123");

//Creates a digital signature.
PdfSignature signature = new PdfSignature(document, page, pdfCert, "Signature");
signature.Settings.CryptographicStandard = CryptographicStandard.CADES;
signature.Settings.DigestAlgorithm = DigestAlgorithm.SHA256;

//Save the document into stream
MemoryStream stream = new MemoryStream();
document.Save(stream);
//Close the document
document.Close(true);

//Load an existing PDF stream.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(stream);

//Gets the first signature field of the PDF document
PdfLoadedSignatureField signatureField = loadedDocument.Form.Fields[0] as PdfLoadedSignatureField;
PdfSignature pdfSignature = signatureField.Signature;

//Enable LTV on Signature.
pdfSignature.EnableLtv = true;


//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);

