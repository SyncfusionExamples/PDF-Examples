using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

// Load the existing PDF document
using (PdfLoadedDocument document = new PdfLoadedDocument(
           Path.GetFullPath(@"Data/Input.pdf")))
{
    // Iterate through all pages in the document
    foreach (PdfLoadedPage page in document.Pages)
    {
        // Remove any JavaScript or actions that execute
        // when the page is opened
        page.Actions.OnOpen = null;
        // Remove any JavaScript or actions that execute
        // when the page is closed
        page.Actions.OnClose = null;
    }
    // Save the modified PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
    // Close the document
    document.Close(true);
}
