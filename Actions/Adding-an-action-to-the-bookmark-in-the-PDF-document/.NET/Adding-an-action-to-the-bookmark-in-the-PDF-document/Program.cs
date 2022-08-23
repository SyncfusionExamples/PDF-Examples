// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new document.
PdfDocument document = new PdfDocument();

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

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
