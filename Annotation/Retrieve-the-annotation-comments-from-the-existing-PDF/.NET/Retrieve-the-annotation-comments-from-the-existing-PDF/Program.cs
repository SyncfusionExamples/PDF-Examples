// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Get stream from the existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Get the existing PDF page.
PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

//Get the annotation.
PdfLoadedRectangleAnnotation loadedMarkup = loadedPage.Annotations[0] as PdfLoadedRectangleAnnotation;

//Get the comments of the annotation.
PdfLoadedPopupAnnotationCollection commentsCollection = loadedMarkup.Comments;

//Closes the document.
loadedDocument.Close(true);
