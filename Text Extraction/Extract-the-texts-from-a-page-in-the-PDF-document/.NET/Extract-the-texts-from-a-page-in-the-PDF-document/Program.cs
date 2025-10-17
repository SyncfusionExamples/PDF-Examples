using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Load the first page.
    PdfPageBase page = loadedDocument.Pages[0];

    //Extract text from first page.
    string extractedText = page.ExtractText();

    //Write the extracted lines in console window. 
    Console.WriteLine("Extracted Text: " + extractedText);
}
