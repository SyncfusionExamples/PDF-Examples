
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;

// Load the existing PDF document using FileStream
using (FileStream inputStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
{
    // Load the PDF document from the input stream
    using (PdfLoadedDocument ldoc = new PdfLoadedDocument(inputStream))
    {
        // Access the first page of the document
        PdfLoadedPage page = ldoc.Pages[0] as PdfLoadedPage;

        // Get the collection of annotations from the page
        PdfLoadedAnnotationCollection annotations = page.Annotations;

        // Check if at least one annotation exists and it's a popup annotation
        if (annotations.Count > 0 && annotations[0] is PdfLoadedPopupAnnotation annotation)
        {
            // Set a custom key-value pair in the annotation's metadata
            annotation.SetValues("custom", "This is the custom data for the annotation");
        }

        // Save the modified document using a new FileStream
        using (FileStream outputStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.Write))
        {
            // Save changes to a new PDF file
            ldoc.Save(outputStream); 
        }
        // Close the document and release resources
        ldoc.Close(true);
    }
}