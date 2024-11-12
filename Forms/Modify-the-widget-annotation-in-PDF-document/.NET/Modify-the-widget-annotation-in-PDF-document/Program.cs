using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;

//Load the PDF document.
FileStream docStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);
// Loop through each page in the loaded PDF document.
foreach (PdfLoadedPage page in loadedDocument.Pages)
{
    // Loop through each annotation on the current page.
    foreach (PdfLoadedAnnotation annot in page.Annotations)
    {
        // Check if the annotation is a widget annotation.
        if (annot is PdfLoadedWidgetAnnotation)
        {
            // Cast the annotation to a PdfLoadedWidgetAnnotation type.
            PdfLoadedWidgetAnnotation widget = annot as PdfLoadedWidgetAnnotation;
            // Set the widget's text value to "true".
            widget.Text = "true";
        }
    }

}
//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}
//Close the document.
loadedDocument.Close(true);