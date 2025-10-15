using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Create the new PDF document.
    PdfDocument document = new PdfDocument();

    //Set the page start and end index to be imported. 
    int startIndex = 0;
    int endIndex = loadedDocument.Pages.Count - 1;

    //Import all the pages to the new PDF document without bookmarks.
    document.ImportPageRange(loadedDocument, startIndex, endIndex, false);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}