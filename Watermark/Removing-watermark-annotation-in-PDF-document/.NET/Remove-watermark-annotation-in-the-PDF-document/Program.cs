using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Load the PDF document
FileStream docStream = new FileStream("../../../Input.pdf", FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

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

//Save the document.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    loadedDocument.Save(outputFileStream);
}
//Close the document.
loadedDocument.Close(true);
