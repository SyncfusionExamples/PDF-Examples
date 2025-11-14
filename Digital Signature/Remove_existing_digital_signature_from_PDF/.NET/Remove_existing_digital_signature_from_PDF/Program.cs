using Syncfusion.Pdf.Parsing;

//Load the PDF document.
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the signature field from PDF form field collection.
    PdfLoadedSignatureField signatureField = loadedDocument.Form.Fields[0] as PdfLoadedSignatureField;
    //Remove signature field from form field collection.
    loadedDocument.Form.Fields.Remove(signatureField);
    //Save the PDF document 
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}