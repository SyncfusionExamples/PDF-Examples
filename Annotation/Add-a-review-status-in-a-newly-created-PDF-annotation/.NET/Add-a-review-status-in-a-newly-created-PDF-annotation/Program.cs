﻿using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Create a new page.
    PdfPage page = document.Pages.Add();

    //Create new rectangle annotation.
    PdfRectangleAnnotation rectangleAnnotation = new PdfRectangleAnnotation(new RectangleF(0, 0, 100, 50), "Rectangle Annotation");

    //Set properties to rectangle annotation.
    rectangleAnnotation.Author = "Syncfusion";
    rectangleAnnotation.Border.BorderWidth = 1;
    rectangleAnnotation.Color = Color.Red;
    rectangleAnnotation.ModifiedDate = DateTime.Now;

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
    rectangleAnnotation.ReviewHistory.Add(review);

    //Add the annotation to the PDF page.
    page.Annotations.Add(rectangleAnnotation);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}