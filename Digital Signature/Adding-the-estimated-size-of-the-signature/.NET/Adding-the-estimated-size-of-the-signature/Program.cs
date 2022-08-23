// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Security;

//Creating a new PDF Document. 
PdfDocument document = new PdfDocument();

//Adding a new page to the PDF document.
PdfPageBase page = document.Pages.Add();

//Creates a certificate instance from the PFX file with a private key.
FileStream certificateStream = new FileStream(Path.GetFullPath("../../../PDF.pfx"), FileMode.Open, FileAccess.Read);
PdfCertificate pdfCert = new PdfCertificate(certificateStream, "syncfusion");

//Add a new signature to the PDF page.
PdfSignature signature = new PdfSignature(document, page, pdfCert, "Signature");
signature.Bounds = new Rectangle(10, 20, 400, 200);

//Sets the estimated size of the signature.
signature.EstimatedSignatureSize = 20000;

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
