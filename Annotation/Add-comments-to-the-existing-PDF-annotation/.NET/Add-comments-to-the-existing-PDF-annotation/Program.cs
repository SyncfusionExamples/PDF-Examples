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

    //Create a new comment annotation.
    PdfPopupAnnotation comment = new PdfPopupAnnotation();

    //Set author.
    comment.Author = "John";

    //Set Text.
    comment.Text = "This is first comment";

    //Set modification date.
    comment.ModifiedDate = DateTime.Now;

    //Set subject.
    comment.Subject = "Annotation Comments";

    //Add the comments to the annotation.
    loadedRectangleAnnotation.Comments.Add(comment);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}