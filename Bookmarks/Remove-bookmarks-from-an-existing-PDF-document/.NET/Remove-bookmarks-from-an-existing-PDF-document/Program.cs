using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Gets all the bookmarks.
    PdfBookmarkBase bookmarks = loadedDocument.Bookmarks;

    //Removes bookmark by bookmark name.
    bookmarks.Remove("Page 1");

    //Removes bookmark by index.
    bookmarks.RemoveAt(1);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}