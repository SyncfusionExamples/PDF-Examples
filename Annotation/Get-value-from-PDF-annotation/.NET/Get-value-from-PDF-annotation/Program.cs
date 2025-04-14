using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;

// Load the existing PDF document using FileStream
using (FileStream inputStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
{
    using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputStream))
    {
        // Get the first page
        PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

        // Get all annotations on the page
        PdfLoadedAnnotationCollection annotations = loadedPage.Annotations;

        // Make sure the 65th annotation exists and is a circle annotation
        if (annotations.Count > 64 && annotations[64] is PdfLoadedCircleAnnotation circleAnnotation)
        {
            // Get the review history from the circle annotation
            PdfLoadedPopupAnnotationCollection reviewHistory = circleAnnotation.ReviewHistory;

            // Ensure review history has at least two items
            if (reviewHistory != null && reviewHistory.Count > 1)
            {
                // Get the second popup annotation from review history
                PdfLoadedPopupAnnotation popupAnnotation = reviewHistory[1] as PdfLoadedPopupAnnotation;

                if (popupAnnotation != null)
                {
                    // Get values for the "State" key
                    List<string> values = popupAnnotation.GetValues("State");
                    foreach (string value in values)
                    {
                        Console.WriteLine(value);
                    }
                }
            }
        }
    }
}
