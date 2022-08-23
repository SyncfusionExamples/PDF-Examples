// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Gets the first page from the document.
PdfLoadedPage page = loadedDocument.Pages[0] as PdfLoadedPage;

//Gets the annotation collection.
PdfLoadedAnnotationCollection annotations = page.Annotations;

//Gets the first ink annotation.
PdfLoadedInkAnnotation inkAnnotation = annotations[0] as PdfLoadedInkAnnotation;

//Gets the ink points collection.
List<List<float>> points = inkAnnotation.InkPointsCollection;

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);