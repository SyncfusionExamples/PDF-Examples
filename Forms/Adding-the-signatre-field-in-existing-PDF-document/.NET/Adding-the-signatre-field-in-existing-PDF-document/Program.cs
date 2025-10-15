using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Create the form if the form does not exist in the loaded document.
    if (loadedDocument.Form == null)
        loadedDocument.CreateForm();

    //Load the page.
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

    //Create PDF Signature field.
    PdfSignatureField signatureField = new PdfSignatureField(loadedPage, "Signature");

    //Set properties to the signature field.
    signatureField.Bounds = new Syncfusion.Drawing.RectangleF(100, 100, 90, 20);
    signatureField.ToolTip = "Signature";

    //Add the form field to the existing document.
    loadedDocument.Form.Fields.Add(signatureField);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}