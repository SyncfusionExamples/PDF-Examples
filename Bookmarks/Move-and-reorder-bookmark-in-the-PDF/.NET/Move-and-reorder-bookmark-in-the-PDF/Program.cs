using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

class Program
{
    static void Main(string[] args)
    {
        // Load the PDF document
        using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
        {
            PdfBookmarkBase bookmarks = loadedDocument.Bookmarks;
            // Reorder: move bookmark from index
            if (bookmarks.Count > 2)
                MoveBookmark(bookmarks, 2, 0, loadedDocument);
            // Remove bookmark by title.
            RemoveBookmarkByTitle(bookmarks, "Bookmark To Remove");
            loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
        }
    }

    // Moves a bookmark from one index to another within its parent collection.
    static void MoveBookmark(PdfBookmarkBase parentCollection, int fromIndex, int toIndex, PdfLoadedDocument document)
    {
        if (fromIndex == toIndex || fromIndex < 0 || fromIndex >= parentCollection.Count)
            return;
        PdfLoadedBookmark sourceBookmark = parentCollection[fromIndex] as PdfLoadedBookmark;
        if (sourceBookmark == null)
            return;
        // Store bookmark details.
        string title = sourceBookmark.Title;
        PdfTextStyle textStyle = sourceBookmark.TextStyle;
        PdfColor color = sourceBookmark.Color;
        PdfDestination destination = sourceBookmark.Destination ?? new PdfDestination(document.Pages[0]);
        List<PdfBookmark> children = new List<PdfBookmark>();
        foreach (PdfBookmark child in sourceBookmark)
            children.Add(child);
        // Remove from original position.
        parentCollection.RemoveAt(fromIndex);
        // Adjust target index.
        int adjustedIndex = toIndex > fromIndex ? toIndex - 1 : toIndex;
        adjustedIndex = Math.Max(0, Math.Min(adjustedIndex, parentCollection.Count));
        // Insert at new position.
        var movedBookmark = parentCollection.Insert(adjustedIndex, title);
        movedBookmark.TextStyle = textStyle;
        movedBookmark.Color = color;
        movedBookmark.Destination = destination;
        // Re-add children.
        foreach (var child in children)
            AddBookmark(movedBookmark, child, document);
    }

    // Clones an existing bookmark (including all descendants) and adds it to a parent.
    static void AddBookmark(PdfBookmark parent, PdfBookmark sourceBookmark, PdfLoadedDocument document)
    {
        if (parent == null || sourceBookmark == null)
            return;
        PdfBookmark newBookmark = parent.Insert(parent.Count, sourceBookmark.Title);
        newBookmark.TextStyle = sourceBookmark.TextStyle;
        newBookmark.Color = sourceBookmark.Color;
        newBookmark.Destination = sourceBookmark.Destination ?? new PdfDestination(document.Pages[0]);
        foreach (PdfBookmark child in sourceBookmark)
            AddBookmark(newBookmark, child, document);
    }

    // Removes the first occurrence of a bookmark with the specified title from a parent (searches recursively).
    static void RemoveBookmarkByTitle(PdfBookmarkBase parent, string title)
    {
        if (parent == null || string.IsNullOrWhiteSpace(title))
            return;

        for (int i = parent.Count - 1; i >= 0; i--)
        {
            PdfBookmark bookmark = parent[i] as PdfBookmark;
            if (bookmark != null)
            {
                RemoveBookmarkByTitle(bookmark, title);
                if (bookmark.Title == title)
                    parent.RemoveAt(i);
            }
        }
    }
}