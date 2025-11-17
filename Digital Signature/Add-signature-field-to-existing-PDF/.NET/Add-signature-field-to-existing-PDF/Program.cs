using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Drawing;

// Load the existing PDF document
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"../../../Data/Input.pdf")))
{
    // Ensure the document has a form; create one if it doesn't exist
    if (loadedDocument.Form == null)
        loadedDocument.CreateForm();
    // Load the first page of the PDF
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;
    // Create a new PDF signature field on the loaded page
    PdfSignatureField signatureField = new PdfSignatureField(loadedPage, "Signature");
    // Set properties for the signature field (position and tooltip)
    signatureField.Bounds = new RectangleF(100, 300, 90, 20);
    signatureField.ToolTip = "Signature";
    // Add the signature field to the form in the existing document
    loadedDocument.Form.Fields.Add(signatureField);
    // Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"../../../Output/Output.pdf"));
}
