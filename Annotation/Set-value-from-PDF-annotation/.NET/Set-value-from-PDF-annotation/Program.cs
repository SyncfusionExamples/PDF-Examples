
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;

// Load the existing PDF document using FileStream
using (FileStream inputStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
{
    using (PdfLoadedDocument ldoc = new PdfLoadedDocument(inputStream))
    {
        // Get the first page
        PdfLoadedPage lpage = ldoc.Pages[0] as PdfLoadedPage;

        // Get all annotations on the page
        PdfLoadedAnnotationCollection annots = lpage.Annotations;

        // Access the 65th annotation (index starts at 0)
        if (annots.Count > 64 && annots[64] is PdfLoadedCircleAnnotation Icircle)
        {
            // Get the author of the circle annotation
            string author = Icircle.Author;

            // Get the review history and comments
            PdfLoadedPopupAnnotationCollection collection = Icircle.ReviewHistory;
            PdfLoadedPopupAnnotationCollection collectionComments = Icircle.Comments;

            // Check if there's at least a second item in the review history
            if (collection != null && collection.Count > 1)
            {
                PdfLoadedPopupAnnotation annotation = collection[1] as PdfLoadedPopupAnnotation;

                if (annotation != null)
                {
                    // Set custom state and state model
                    annotation.SetValues("State", "Unknown");
                    annotation.SetValues("StateModel", "CustomState");
                }
            }
        }

        // Save the modified document using FileStream
        using (FileStream outputStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.Write))
        {
            ldoc.Save(outputStream);
        }

        ldoc.Close(true);
    }
}