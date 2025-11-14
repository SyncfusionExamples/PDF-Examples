using Syncfusion.Pdf.Parsing;

//Load the PDF document.
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Gets an array of revisions. 
    PdfRevision[] revisions = loadedDocument.Revisions;
    foreach (PdfRevision rev in revisions)
    {
        //Get revision start position.
        long startPosition = rev.StartPosition;
    }
    //Load the existing signature field.
    PdfLoadedSignatureField loadedSignatureField = loadedDocument.Form.Fields[0] as PdfLoadedSignatureField;
    //Get the revision of the signature.
    int revisionIndex = loadedSignatureField.Revision;
    Console.WriteLine("Revison index of the signature field is " + revisionIndex);
}