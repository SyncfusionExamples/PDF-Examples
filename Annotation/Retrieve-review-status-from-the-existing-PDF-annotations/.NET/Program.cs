﻿// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Get the existing PDF page.
PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

//Get the annotation.
PdfLoadedRectangleAnnotation rectangleAnnotation = loadedPage.Annotations[0] as PdfLoadedRectangleAnnotation;

//Get the review history collection for the annotation.
PdfLoadedPopupAnnotationCollection reviewCollection = rectangleAnnotation.ReviewHistory;

//Iterate through the review history collection.
foreach (PdfLoadedPopupAnnotation review in reviewCollection)
{
    //Get the author of the annotation.
    string author = review.Author;
    //Get the state of the annotation.
    PdfAnnotationState state = review.State;
    //Get the state model of the annotation.
    PdfAnnotationStateModel model = review.StateModel;

    Console.WriteLine("Author of the reviewer: " + author + "\r\nState: " + state + "\r\nState Model: " + model);
}

//Closes the document.
loadedDocument.Close(true);
