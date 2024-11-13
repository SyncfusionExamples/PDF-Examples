using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;

//Load the PDF document.
FileStream docStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);
// Loop through each page in the loaded PDF document.
foreach (PdfLoadedPage page in loadedDocument.Pages)
{
    // Initialize the widget count to zero.
    int widgetCount = 0;
    // Loop through each annotation on the current page.
    foreach (PdfLoadedAnnotation annot in page.Annotations)
    {
        // Check if the annotation is a widget annotation.
        if (annot is PdfLoadedWidgetAnnotation)
        {
            // Cast the annotation to a PdfLoadedWidgetAnnotation type.
            PdfLoadedWidgetAnnotation widget = annot as PdfLoadedWidgetAnnotation;
            // Retrieve the bounds of the widget annotation.
            RectangleF bounds = widget.Bounds;
            // Display the index and bounds value of the widget annotation.
            Console.WriteLine("Index: {0}, Bounds Value: {1}", widgetCount, bounds);
            // Increment the widget count.
            widgetCount++;
        }
    }
    // Display the total number of widget annotations.
    Console.WriteLine("Total number of widgets: {0}", widgetCount);
}
//Close the document.
loadedDocument.Close(true);