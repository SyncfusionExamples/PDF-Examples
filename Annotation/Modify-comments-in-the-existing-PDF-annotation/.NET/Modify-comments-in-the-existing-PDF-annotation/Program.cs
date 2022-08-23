// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

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

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);