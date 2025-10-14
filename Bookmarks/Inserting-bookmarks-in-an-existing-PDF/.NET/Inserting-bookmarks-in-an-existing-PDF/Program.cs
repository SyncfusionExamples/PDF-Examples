using Syncfusion.Drawing;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Inserts a new bookmark in the existing bookmark collection.
    PdfBookmark bookmark = loadedDocument.Bookmarks.Insert(1, "New Page 2");

    //Sets the destination page and location.
    bookmark.Destination = new PdfDestination(loadedDocument.Pages[1]);
    bookmark.Destination.Location = new PointF(0, 300);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}