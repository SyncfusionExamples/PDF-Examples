// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;

//Load an existing PDF document.
FileStream docStream = new FileStream(Path.GetFullPath("../../../SignedPDF.pdf"), FileMode.Open, FileAccess.Read);
PdfLoadedDocument pdfLoadedDocument = new PdfLoadedDocument(docStream);

//Get the signature field from PDF form field collection.
PdfLoadedSignatureField signatureField = pdfLoadedDocument.Form.Fields[0] as PdfLoadedSignatureField;

//Remove signature field from form field collection.
pdfLoadedDocument.Form.Fields.Remove(signatureField);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    pdfLoadedDocument.Save(outputFileStream);
}

//Close the document.
pdfLoadedDocument.Close(true);
