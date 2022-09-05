// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document.  
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Get the named destination collection.
PdfNamedDestinationCollection destinationCollection = loadedDocument.NamedDestinationCollection;

//Remove the named destination by title.
destinationCollection.Remove("POC");

//Modify the exiting named destination
PdfNamedDestination destination = destinationCollection[0];
destination.Title = "Modified Named Destination";

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
