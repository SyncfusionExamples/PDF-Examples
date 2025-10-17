using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the existing PDF page.
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

    //Get the existing annotations.
    PdfLoadedAnnotationCollection annotationCollection = loadedPage.Annotations;

    //Get the existing rectangle annotation.
    PdfLoadedRectangleAnnotation loadedRectangleAnnotation = annotationCollection[0] as PdfLoadedRectangleAnnotation;

    //Get the annotation review collection.
    PdfLoadedPopupAnnotationCollection reviewCollection = loadedRectangleAnnotation.ReviewHistory;

    //Get the modified review state.
    PdfLoadedPopupAnnotation loadedReview = reviewCollection[0];

    //Modify the review State.
    loadedReview.State = PdfAnnotationState.Rejected;

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}