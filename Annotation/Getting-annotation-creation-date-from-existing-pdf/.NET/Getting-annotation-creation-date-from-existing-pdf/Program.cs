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
        // Identify the type of the annotation and process accordingly
        switch (annotations[j].GetType().ToString())
        {
            case "Syncfusion.Pdf.Interactive.PdfLoadedFreeTextAnnotation":
                // Handle FreeText annotation
                PdfLoadedFreeTextAnnotation freeTextAnnot = annotations[j] as PdfLoadedFreeTextAnnotation;
                DateTime creationDate0 = freeTextAnnot.CreationDate;
                Console.WriteLine(creationDate0);
                break;

            case "Syncfusion.Pdf.Interactive.PdfLoadedEllipseAnnotation":
                // Handle Ellipse annotation
                PdfLoadedEllipseAnnotation ellipseAnnot = annotations[j] as PdfLoadedEllipseAnnotation;
                DateTime creationDate1 = ellipseAnnot.CreationDate;
                Console.WriteLine(creationDate1);
                break;

            case "Syncfusion.Pdf.Interactive.PdfLoadedRectangleAnnotation":
                // Handle Rectangle annotation
                PdfLoadedRectangleAnnotation rectangleAnnot = annotations[j] as PdfLoadedRectangleAnnotation;
                DateTime creationDate2 = rectangleAnnot.CreationDate;
                Console.WriteLine(creationDate2);
                break;

            case "Syncfusion.Pdf.Interactive.PdfLoadedSquareAnnotation":
                // Handle Square annotation
                PdfLoadedSquareAnnotation squareAnnot = annotations[j] as PdfLoadedSquareAnnotation;
                DateTime creationDate3 = squareAnnot.CreationDate;
                Console.WriteLine(creationDate3);
                break;

            case "Syncfusion.Pdf.Interactive.PdfLoadedAnnotation":
                // Handle Circle annotation
                PdfLoadedCircleAnnotation circleAnnot = annotations[j] as PdfLoadedCircleAnnotation;
                DateTime creationDate4 = circleAnnot.CreationDate;
                Console.WriteLine(creationDate4);
                break;

            case "Syncfusion.Pdf.Interactive.PdfLoadedLineAnnotation":
                // Handle Line annotation
                PdfLoadedLineAnnotation lineAnnot = annotations[j] as PdfLoadedLineAnnotation;
                DateTime creationDate5 = lineAnnot.CreationDate;
                Console.WriteLine(creationDate5);
                break;

            case "Syncfusion.Pdf.Interactive.PdfLoadedInkAnnotation":
                // Handle Ink annotation
                PdfLoadedInkAnnotation inkAnnot = annotations[j] as PdfLoadedInkAnnotation;
                DateTime creationDate6 = inkAnnot.CreationDate;
                Console.WriteLine(creationDate6);
                break;

            case "Syncfusion.Pdf.Interactive.PdfLoadedRubberStampAnnotation":
                // Handle Rubber Stamp annotation
                PdfLoadedRubberStampAnnotation stampAnnot = annotations[j] as PdfLoadedRubberStampAnnotation;
                DateTime creationDate7 = stampAnnot.CreationDate;
                Console.WriteLine(creationDate7);
                break;

            case "Syncfusion.Pdf.Interactive.PdfLoadedTextMarkupAnnotation":
                // Handle Text Markup annotation
                PdfLoadedTextMarkupAnnotation textAnnot = annotations[j] as PdfLoadedTextMarkupAnnotation;
                DateTime creationDate8 = textAnnot.CreationDate;
                Console.WriteLine(creationDate8);
                break;
        }
    }
}
