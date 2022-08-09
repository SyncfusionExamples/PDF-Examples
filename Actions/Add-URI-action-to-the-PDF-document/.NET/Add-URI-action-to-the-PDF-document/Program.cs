// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new document with PDF/A standard.
PdfDocument document = new PdfDocument();

//Create a uri action.
PdfUriAction uriAction = new PdfUriAction("http://www.google.com");

//Add the action to the document.
document.Actions.AfterOpen = uriAction;

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);