using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the existing PDF page.
    PdfLoadedPage lpage = loadedDocument.Pages[0] as PdfLoadedPage;

    //Get the existing annotations.
    PdfLoadedAnnotationCollection annots = lpage.Annotations;

    //Get the existing rectangle annotation.
    PdfLoadedRectangleAnnotation loadedRectangleAnnotation = annots[0] as PdfLoadedRectangleAnnotation;

    //Create a new review annotation.
    PdfPopupAnnotation review = new PdfPopupAnnotation();

    //Set author.
    review.Author = "John";

    //Set review state model.
    review.StateModel = PdfAnnotationStateModel.Review;

    //Set review state.
    review.State = PdfAnnotationState.Accepted;

    //Set modification date.
    review.ModifiedDate = DateTime.Now;

    //Add the review to the annotation.
    loadedRectangleAnnotation.ReviewHistory.Add(review);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
