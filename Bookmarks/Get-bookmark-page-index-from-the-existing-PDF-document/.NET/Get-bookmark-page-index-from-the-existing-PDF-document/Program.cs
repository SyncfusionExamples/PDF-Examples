using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Gets all the bookmarks.
    PdfBookmarkBase bookmark = loadedDocument.Bookmarks;

    //Get the bookmark page index. 
    int pageIndex = bookmark[1].Destination.PageIndex;

    //Write the page index of the bookmark in console window. 
    Console.WriteLine("Page index of bookmark[1]: " + pageIndex);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}



