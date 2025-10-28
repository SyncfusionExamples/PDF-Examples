using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

// Load the PDF document
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Initialize an empty string to store extracted text
    string extractedText = string.Empty;
    // Extract text from each page in the document
    foreach (PdfLoadedPage page in loadedDocument.Pages)
    {
        extractedText += page.ExtractText();
    }
    // Display the extracted text in the console
    Console.WriteLine("Extracted text from the entire document: " + extractedText);
}
