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

    //Get the annotation  reviewcollection.
    PdfLoadedPopupAnnotationCollection reviewCollection = loadedRectangleAnnotation.ReviewHistory;

    //Remove review status by index.
    reviewCollection.RemoveAt(0);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}