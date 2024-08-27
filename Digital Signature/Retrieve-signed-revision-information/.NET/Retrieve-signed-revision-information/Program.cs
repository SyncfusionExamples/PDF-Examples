// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;

//Loads an existing document
FileStream docStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read);
PdfLoadedDocument document = new PdfLoadedDocument(docStream);

//Gets an array of revisions. 
PdfRevision[] revisions = document.Revisions;
foreach (PdfRevision rev in revisions)
{
    //Get revision start position.
    long startPosition = rev.StartPosition;
}

//Load the existing signature field.
PdfLoadedSignatureField loadedSignatureField = document.Form.Fields[0] as PdfLoadedSignatureField;
//Get the revision of the signature.
int revisionIndex = loadedSignatureField.Revision;

//Close the document.
document.Close(true);

Console.WriteLine("Revison index of the signature field is " + revisionIndex);
Console.ReadLine();
