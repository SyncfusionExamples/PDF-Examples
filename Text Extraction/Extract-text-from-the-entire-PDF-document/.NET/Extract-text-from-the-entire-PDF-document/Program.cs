// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

// Open existing PDF document stream.
using (FileStream inputStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
{
    // Load the PDF document.
    using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputStream))
    {
        string extractedText = string.Empty;
        
        // Extract all text from PDF document pages.
        foreach (PdfLoadedPage page in loadedDocument.Pages)
        {
            extractedText += page.ExtractText();
        }

        //Write the extracted text in console window.
        Console.WriteLine("Extracted text from the entire document: " + extractedText);
        Console.ReadLine();
    }
}
