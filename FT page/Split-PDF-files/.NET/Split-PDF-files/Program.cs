using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

// Create the FileStream object to read the input PDF file
using (FileStream inputFileStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
{
    // Load the PDF document from the input stream
    using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputFileStream))
    {
        // Iterate over the pages of the loaded document
        for (int pageIndex = 0; pageIndex < loadedDocument.PageCount; pageIndex++)
        {
            // Create a new PdfDocument object to hold the output
            using (PdfDocument outputDocument = new PdfDocument())
            {
                // Import the page from the loadedDocument to the outputDocument
                outputDocument.ImportPage(loadedDocument, pageIndex);

                // Create the FileStream object to write the output PDF file
                using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/" + pageIndex + ".pdf"), FileMode.Create, FileAccess.Write))
                {
                    // Save the outputDocument into the outputFileStream
                    outputDocument.Save(outputFileStream);
                }
            }
        }
    }
}
