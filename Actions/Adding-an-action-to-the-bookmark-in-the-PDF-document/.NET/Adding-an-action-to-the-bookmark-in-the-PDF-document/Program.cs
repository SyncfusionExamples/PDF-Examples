using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page.
    PdfPage page = document.Pages.Add();

    //Create document bookmarks.
    PdfBookmark bookmark = document.Bookmarks.Add("Page 1");

    //Set the text style and color.
    bookmark.TextStyle = PdfTextStyle.Bold;
    bookmark.Color = Color.Red;

    //Create a Uri action.
    PdfUriAction uriAction = new PdfUriAction("http://www.google.com");

    //Set the Uri action.
    bookmark.Action = uriAction;

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
