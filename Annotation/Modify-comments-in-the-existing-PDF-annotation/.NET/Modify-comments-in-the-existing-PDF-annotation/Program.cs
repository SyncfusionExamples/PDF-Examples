using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Load the PDF document page.
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

    //Get the annotation collection from PDF page. 
    PdfLoadedAnnotationCollection annotationCollection = loadedPage.Annotations;

    //Load the rectangle annotation.
    PdfLoadedRectangleAnnotation loadedRectangleAnnotation = annotationCollection[0] as PdfLoadedRectangleAnnotation;

    //Get the annotation comments collection.
    PdfLoadedPopupAnnotationCollection commentsCollection = loadedRectangleAnnotation.Comments;

    //Get the modified comment.
    PdfLoadedPopupAnnotation loadedComments = commentsCollection[0];

    //Modify the comment Text.
    loadedComments.Text = "This is the modified comments";

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}