// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Loading page collections.
PdfLoadedPageCollection loadedPages = loadedDocument.Pages;

string extractedText = string.Empty;

//Extract text from existing PDF document pages.
foreach (PdfLoadedPage loadedPage in loadedPages)
{
    extractedText += loadedPage.ExtractText();
}

//Close the document.
loadedDocument.Close(true);

//Write the extracted text in console window.
Console.WriteLine("Extracted text from the entire document: " + extractedText);
Console.ReadLine();
