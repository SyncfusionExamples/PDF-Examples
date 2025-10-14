using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Access the first page of the document
    PdfLoadedPage page = loadedDocument.Pages[0] as PdfLoadedPage;
    // Get the collection of annotations from the page
    PdfLoadedAnnotationCollection annotations = page.Annotations;

    // Check if at least one annotation exists and it's a popup annotation
    if (annotations.Count > 0 && annotations[0] is PdfLoadedPopupAnnotation annotation)
    {
        // Get the custom value from the annotation
        List<string> customValue = annotation.GetValues("custom");

        foreach (string value in customValue)
        {
            // Print the custom value to the console
            Console.WriteLine("Custom value from annotation: " + value);
        }
    }
}
