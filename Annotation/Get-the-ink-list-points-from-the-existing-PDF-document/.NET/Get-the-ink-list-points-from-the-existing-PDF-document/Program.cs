using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Gets the first page from the document.
    PdfLoadedPage page = loadedDocument.Pages[0] as PdfLoadedPage;

    //Gets the annotation collection.
    PdfLoadedAnnotationCollection annotations = page.Annotations;

    //Gets the first ink annotation.
    PdfLoadedInkAnnotation inkAnnotation = annotations[0] as PdfLoadedInkAnnotation;

    //Gets the ink points collection.
    List<List<float>> points = inkAnnotation.InkPointsCollection;

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}