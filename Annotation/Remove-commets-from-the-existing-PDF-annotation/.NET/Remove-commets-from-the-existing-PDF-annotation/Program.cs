using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the existing PDF page.
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

    //Get the existing annotations.
    PdfLoadedAnnotationCollection annots = loadedPage.Annotations;

    //Get the existing rectangle annotation.
    PdfLoadedRectangleAnnotation loadedRectangleAnnotation = annots[0] as PdfLoadedRectangleAnnotation;

    //Get the annotation comments collection.
    PdfLoadedPopupAnnotationCollection commentsCollection = loadedRectangleAnnotation.Comments;

    //Remove comments by index.
    commentsCollection.RemoveAt(0);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
