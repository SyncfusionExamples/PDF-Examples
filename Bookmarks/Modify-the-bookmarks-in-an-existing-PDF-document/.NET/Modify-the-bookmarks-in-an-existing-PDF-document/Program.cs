using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Gets all the bookmarks.
    PdfBookmarkBase bookmarks = loadedDocument.Bookmarks;

    //Gets the first bookmark and changes the properties of the bookmark.
    PdfLoadedBookmark bookmark = bookmarks[0] as PdfLoadedBookmark;
    bookmark.Destination = new PdfDestination(loadedDocument.Pages[0]);
    bookmark.Color = Syncfusion.Drawing.Color.Green;
    bookmark.TextStyle = PdfTextStyle.Bold;
    bookmark.Title = "Changed title";

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}


