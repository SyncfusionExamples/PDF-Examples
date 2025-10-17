using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Load first page.
    PdfPageBase page = loadedDocument.Pages[0];

    //Extract text from first page.
    string extractedTexts = page.ExtractText(true);

    Console.WriteLine("Extracted text: " + extractedTexts);
}