// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document.
FileStream inputFileStream = new FileStream(Path.GetFullPath(@"../../../Input.pdf"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputFileStream);

//Create the new PDF document.
PdfDocument document = new PdfDocument();

//Set the page start and end index to be imported. 
int startIndex = 0;
int endIndex = loadedDocument.Pages.Count - 1;

//Import all the pages to the new PDF document without bookmarks.
document.ImportPageRange(loadedDocument, startIndex, endIndex, false);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Closes both document instances.
loadedDocument.Close(true);
document.Close(true);