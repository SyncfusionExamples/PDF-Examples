using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
class Program
{
    static void Main(string[] args)
    {
        // Load the PDF document from disk.
        using (FileStream docStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
        {
            // Load the PDF document into memory.
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

            // Access the root bookmark collection of the document.
            PdfBookmarkBase bookmarks = loadedDocument.Bookmarks;

            // Move a bookmark from index 2 to index 0 (reorder).
            MoveBookmark(bookmarks, 2, 0, loadedDocument);

            // Remove a bookmark by its title (removes the first match found in hierarchy).
            RemoveBookmarkByTitle(bookmarks, "Bookmark To Remove");

            //Create file stream.
            using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
            {
                loadedDocument.Save(outputFileStream);
            }

            loadedDocument.Close(true);
        }
    }

    // Moves a bookmark from one index to another within its parent collection.
    static void MoveBookmark(PdfBookmarkBase parentCollection, int fromIndex, int toIndex, PdfLoadedDocument document)
    {
        if (fromIndex == toIndex) return; // No move required if indices are the same.

        // Safely cast the bookmark to be moved.
        PdfLoadedBookmark bookmarkToMove = parentCollection[fromIndex] as PdfLoadedBookmark;
        if (bookmarkToMove == null) return;

        // Remove the bookmark from its original location.
        parentCollection.RemoveAt(fromIndex);

        // Remove any existing bookmark with the same title at the new location to avoid duplicates.
        RemoveBookmarkByTitle(parentCollection, bookmarkToMove.Title);

        // Insert the bookmark at the new index.
        PdfBookmark newBookmark = parentCollection.Insert(toIndex, bookmarkToMove.Title);
        newBookmark.TextStyle = bookmarkToMove.TextStyle;
        newBookmark.Color = bookmarkToMove.Color;

        // Set the destination (page location/zoom) for the moved bookmark.
        newBookmark.Destination = bookmarkToMove.Destination ?? new PdfDestination(document.Pages[0])
        {
            Location = bookmarkToMove.Destination?.Location ?? new PointF(0, 0),
            Zoom = bookmarkToMove.Destination?.Zoom ?? 1F
        };

        // Move all child bookmarks recursively.
        foreach (PdfBookmark child in bookmarkToMove)
        {
            AddBookmark(newBookmark, child, document);
        }
    }

    // Clones an existing bookmark (including all descendants) and adds it to a parent.
    static void AddBookmark(PdfBookmark parent, PdfBookmark bookmark, PdfLoadedDocument document)
    {
        // Remove any even-closer duplicate title children before insertion.
        RemoveBookmarkByTitle(parent, bookmark.Title);

        PdfBookmark newChild = parent.Insert(parent.Count, bookmark.Title);
        newChild.Destination = bookmark.Destination ?? new PdfDestination(document.Pages[0])
        {
            Location = new PointF(0, 0),
            Zoom = 1F
        };
        newChild.TextStyle = bookmark.TextStyle;
        newChild.Color = bookmark.Color;

        // Recursively clone and add children.
        foreach (PdfBookmark child in bookmark)
        {
            AddBookmark(newChild, child, document);
        }
    }

    // Removes the first occurrence of a bookmark with the specified title from a parent (searches recursively).
    static void RemoveBookmarkByTitle(PdfBookmarkBase parent, string title)
    {
        for (int i = 0; i < parent.Count;)
        {
            if (parent[i].Title == title)
            {
                parent.RemoveAt(i);
                continue;
            }
            if (parent[i] is PdfBookmark child)
            {
                RemoveBookmarkByTitle(child, title); // Recurse for children
            }
            i++;
        }
    }
}