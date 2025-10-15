using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the named destination collection.
    PdfNamedDestinationCollection destinationCollection = loadedDocument.NamedDestinationCollection;

    //Remove the named destination by title.
    destinationCollection.Remove("POC");

    //Modify the exiting named destination
    PdfNamedDestination destination = destinationCollection[0];
    destination.Title = "Modified Named Destination";

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
