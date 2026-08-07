using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

// Load the PDF document
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Get the first page of the document
    PdfLoadedPage page = loadedDocument.Pages[0] as PdfLoadedPage;
    // Get the annotation collection from the page
    PdfLoadedAnnotationCollection annotations = page.Annotations;
    // Get the first annotation (assumed to be a rectangle annotation)
    PdfLoadedRectangleAnnotation annot = annotations[8] as PdfLoadedRectangleAnnotation;
    // Try to get the custom value "Subtype" from the annotation
    object values;
    bool foundValue = annot.TryGetValue("Subtype", out values);
    // Check and print the values if found
    if (foundValue && values is List<string> stringValues)
    {
        foreach (string value in stringValues)
        {
            // Print the custom value to the console
            Console.WriteLine($"Found Subtype value: {value}");
        }
    }
    else
    {
        Console.WriteLine("Subtype value not found.");
    }
}