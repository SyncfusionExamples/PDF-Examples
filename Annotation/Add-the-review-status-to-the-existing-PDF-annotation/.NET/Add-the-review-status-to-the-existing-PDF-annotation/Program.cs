// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

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

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
