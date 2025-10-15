using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a new page to PDF document.
    PdfPage page = document.Pages.Add();

    //Create PDF Signature field.
    PdfSignatureField signatureField = new PdfSignatureField(page, "Signature");

    //Set properties to the signature field.
    signatureField.Bounds = new Syncfusion.Drawing.RectangleF(50, 50, 90, 20);
    signatureField.ToolTip = "Signature";

    //Add the form field to the document.
    document.Form.Fields.Add(signatureField);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
