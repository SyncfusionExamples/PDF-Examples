using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;

// Create a PdfLoadedDocument object 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputFileStream,"password"))
{
    // Iterate over the pages in the PdfLoadedDocument object  
    for (int pageIndex = 0; pageIndex < loadedDocument.PageCount; pageIndex++)
    {
        // Create a new PdfDocument object  
        using (PdfDocument outputDocument = new PdfDocument())
        {
            // Import the page from the PdfLoadedDocument object to the PdfDocument object  
            outputDocument.ImportPage(loadedDocument, pageIndex);
            //Save the document
            outputDocument.Save(Path.GetFullPath(@"Output/Output" + pageIndex + ".pdf"));
        }
    }
}