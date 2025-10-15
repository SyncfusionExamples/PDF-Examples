using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the first page of the PDF document. 
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

    //Get the loaded form.
    PdfLoadedForm loadedForm = loadedDocument.Form;

    //Create PDF Certificate
    FileStream certificateStream = new FileStream(Path.GetFullPath(@"Data/PDF.pfx"), FileMode.Open, FileAccess.Read);
    PdfCertificate certificate = new PdfCertificate(certificateStream, "syncfusion");

    //Load the signature field from field collection and fill this with certificate.
    PdfLoadedSignatureField loadedSignatureField = loadedForm.Fields[9] as PdfLoadedSignatureField;
    loadedSignatureField.Signature = new PdfSignature(loadedDocument, loadedPage, certificate, "Signature", loadedSignatureField);
    loadedSignatureField.Signature.Certificate = certificate;
    loadedSignatureField.Signature.Reason = "Reason";

    //Get stream from an image file.
    FileStream imageStream = new FileStream(Path.GetFullPath(@"Data/signature.jpg"), FileMode.Open, FileAccess.Read);

    //Load the image.
    PdfBitmap image = new PdfBitmap(imageStream);

    //Draw image in the signature appearance. 
    loadedSignatureField.Signature.Appearance.Normal.Graphics.DrawImage(image, new PointF(0, 0), new SizeF(loadedSignatureField.Bounds.Width, loadedSignatureField.Bounds.Height));

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}