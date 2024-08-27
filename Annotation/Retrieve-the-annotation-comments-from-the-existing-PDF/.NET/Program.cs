// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Get stream from the existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Get the existing PDF page.
PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

//Get the annotation.
PdfLoadedRectangleAnnotation rectangleAnnotation = loadedPage.Annotations[0] as PdfLoadedRectangleAnnotation;

//Get the comments of the annotation.
PdfLoadedPopupAnnotationCollection commentsCollection = rectangleAnnotation.Comments;

//Iterate through the comments collection.
foreach (PdfLoadedPopupAnnotation comment in commentsCollection)
{
    //Get the author of the comment.
    string author = comment.Author;
    //Get the content
    string content = comment.Text;

    Console.WriteLine("Author of the comment: " + author + "\r\nContent: " + content);
}

//Closes the document.
loadedDocument.Close(true);
