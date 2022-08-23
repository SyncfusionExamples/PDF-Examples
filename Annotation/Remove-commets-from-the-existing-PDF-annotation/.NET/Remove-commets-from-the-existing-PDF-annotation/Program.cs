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

//Get the existing annotations.
PdfLoadedAnnotationCollection annots = loadedPage.Annotations;

//Get the existing rectangle annotation.
PdfLoadedRectangleAnnotation loadedRectangleAnnotation = annots[0] as PdfLoadedRectangleAnnotation;

//Get the annotation comments collection.
PdfLoadedPopupAnnotationCollection commentsCollection = loadedRectangleAnnotation.Comments;

//Remove comments by index.
commentsCollection.RemoveAt(0);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
