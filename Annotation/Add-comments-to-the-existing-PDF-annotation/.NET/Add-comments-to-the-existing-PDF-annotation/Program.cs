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

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);