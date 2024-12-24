using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;

// Load the PDF document
FileStream inputStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read);
PdfLoadedDocument document = new PdfLoadedDocument(inputStream);
// Load the collection of pages in the PDF document
PdfLoadedPageCollection loadedPages = document.Pages;

// Iterate through all the pages in the document
for (int i = 0; i < loadedPages.Count; i++)
{
    // Access the current page
    PdfLoadedPage loadedPage = loadedPages[i] as PdfLoadedPage;
    // Access the annotation collection on the current page
    PdfLoadedAnnotationCollection annotations = loadedPage.Annotations;
    // Get the total number of annotations on the current page
    int numAnnotations = annotations.Count;
    // Iterate through all annotations on the current page
    for (int j = 0; j < numAnnotations; j++)
    {
        // Iterate through rectangle annotations
        if (annotations[j].GetType().ToString() == "Syncfusion.Pdf.Interactive.PdfLoadedRectangleAnnotation")
        {
            // Handle rectangle annotation
            PdfLoadedRectangleAnnotation rectangleAnnot = annotations[j] as PdfLoadedRectangleAnnotation;
            DateTime creationDate = rectangleAnnot.CreationDate;
            Console.WriteLine(creationDate);
        }
    }
}
//Close the document
document.Close(true);
inputStream.Dispose();
