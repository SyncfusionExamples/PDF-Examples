using Syncfusion.Drawing;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Creates document bookmarks.
    PdfBookmark bookmark = loadedDocument.Bookmarks.Add("Page 1");

    //Sets the destination page.
    bookmark.Destination = new PdfDestination(loadedDocument.Pages[0]);

    //Sets the text style and color.
    bookmark.TextStyle = PdfTextStyle.Bold;
    bookmark.Color = Color.Red;

    //Sets the destination location.
    bookmark.Destination.Location = new PointF(20, 20);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
