// See https://aka.ms/new-console-template for more information
 
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document.
FileStream docStream = new FileStream(Path.GetFullPath("../../../input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Gets all the bookmarks.
PdfBookmarkBase bookmark = loadedDocument.Bookmarks;

//Get the bookmark page index. 
int pageIndex = bookmark[1].Destination.PageIndex;

//Close the document. 
loadedDocument.Close(true);

//Write the page index of the bookmark in console window. 
Console.WriteLine("Page index of bookmark[1]: " + pageIndex);
Console.ReadLine();



