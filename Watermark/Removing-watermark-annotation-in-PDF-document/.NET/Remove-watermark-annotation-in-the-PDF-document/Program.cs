using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Iterate through the annotations collection and remove PdfLoadedWatermark annotations
    foreach (PdfPageBase page in loadedDocument.Pages)
    {
        for (int i = page.Annotations.Count - 1; i >= 0; i--)
        {
            // Check if the annotation is a PdfLoadedWatermarkAnnotation
            if (page.Annotations[i] is PdfLoadedWatermarkAnnotation)
            {
                // Remove the PdfLoadedWatermarkAnnotation
                page.Annotations.RemoveAt(i);
            }
        }
    }

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
