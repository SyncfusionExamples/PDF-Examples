using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;

// Load the PDF document using a file stream
FileStream inputStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read);
PdfLoadedDocument document = new PdfLoadedDocument(inputStream);

// Load the page collection from the PDF document
PdfLoadedPageCollection loadedPages = document.Pages;

// Iterate through all pages in the document
for (int i = 0; i < loadedPages.Count; i++)
{
    // Access each page
    PdfLoadedPage loadedPage = loadedPages[i] as PdfLoadedPage;

    // Check if the page contains annotations
    if (loadedPage.Annotations.Count > 0)
    {
        // Iterate through each annotation on the page
        foreach (PdfLoadedAnnotation annot in loadedPage.Annotations)
        {
            // Identify the type of the annotation
            PdfLoadedAnnotationType annotationType;

            if (annot is PdfLoadedRectangleAnnotation)
            {
                annotationType = PdfLoadedAnnotationType.RectangleAnnotation;
            }
            else if (annot is PdfLoadedTextMarkupAnnotation)
            {
                annotationType = PdfLoadedAnnotationType.TextMarkupAnnotation;
            }
            else if (annot is PdfLoadedTextWebLinkAnnotation)
            {
                annotationType = PdfLoadedAnnotationType.TextWebLinkAnnotation;
            }
            else if (annot is PdfLoadedPopupAnnotation)
            {
                annotationType = PdfLoadedAnnotationType.PopupAnnotation;
            }
            else
            {
                annotationType = PdfLoadedAnnotationType.Null;
            }

            // Print the annotation type to the console
            Console.WriteLine(annotationType);
        }
    }
}

// Close the document and release resources
document.Close(true);
inputStream.Dispose();
Console.ReadKey();