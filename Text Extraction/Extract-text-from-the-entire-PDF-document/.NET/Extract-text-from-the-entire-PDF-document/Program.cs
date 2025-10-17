using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    string extractedText = string.Empty;

    // Extract all text from PDF document pages.
    foreach (PdfLoadedPage page in loadedDocument.Pages)
    {
        extractedText += page.ExtractText();
    }

    //Write the extracted text in console window.
    Console.WriteLine("Extracted text from the entire document: " + extractedText);
}
