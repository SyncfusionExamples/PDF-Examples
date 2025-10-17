using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;

// Load the PDF document 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    PdfBookmarkBase bookmarks = loadedDocument.Bookmarks;
    // Iterate all the bookmarks and their page ranges 
    foreach (PdfBookmark bookmark in bookmarks)
    {
        if (bookmark.Destination != null)
        {
            if (bookmark.Destination.Page != null)
            {
                int endIndex = bookmark.Destination.PageIndex;
                int count = 0;
                // Create a new PDF document
                using (PdfDocument document = new PdfDocument())
                {
                    foreach (PdfLoadedBookmark childBookmark in bookmark)
                    {
                        endIndex = childBookmark.Destination.PageIndex;
                    }
                    // Import the pages to the new PDF document 
                    document.ImportPageRange(loadedDocument, bookmark.Destination.PageIndex, endIndex);
                    //Save the document
                    document.Save(Path.GetFullPath(@"Output/" + bookmark.Title +".pdf"));
                }
            }
        }
    }
}