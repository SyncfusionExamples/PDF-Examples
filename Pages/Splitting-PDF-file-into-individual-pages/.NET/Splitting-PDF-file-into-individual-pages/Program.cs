using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Iterate over the pages of the loaded document
    for (int pageIndex = 0; pageIndex < loadedDocument.PageCount; pageIndex++)
    {
        // Create a new PdfDocument object to hold the output
        using (PdfDocument outputDocument = new PdfDocument())
        {
            // Import the page from the loadedDocument to the outputDocument
            outputDocument.ImportPage(loadedDocument, pageIndex);
            //Save the PDF document
            outputDocument.Save(Path.GetFullPath(@"Output/" + pageIndex + ".pdf"));
        }
    }
}