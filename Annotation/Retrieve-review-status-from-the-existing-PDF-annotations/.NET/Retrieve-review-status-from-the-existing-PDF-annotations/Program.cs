// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Get the existing PDF page.
PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

//Get the annotation.
PdfLoadedRectangleAnnotation loadedMarkup = loadedPage.Annotations[0] as PdfLoadedRectangleAnnotation;

//Get the review history collection for the annotation.
PdfLoadedPopupAnnotationCollection reviewCollection = loadedMarkup.ReviewHistory;

//Get annotation state.
PdfAnnotationState state = reviewCollection[0].State;

//Get annotation state model.
PdfAnnotationStateModel model = reviewCollection[0].StateModel;

//Get the comments of the annotation.
PdfLoadedPopupAnnotationCollection commentsCollection = loadedMarkup.Comments;

//Get the review history of the comment.
PdfLoadedPopupAnnotationCollection reviewCollection1 = commentsCollection[0].ReviewHistory;

//Closes the document.
loadedDocument.Close(true);
