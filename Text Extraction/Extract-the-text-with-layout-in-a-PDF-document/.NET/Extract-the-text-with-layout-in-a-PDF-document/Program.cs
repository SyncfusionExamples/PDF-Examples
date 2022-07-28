// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Load first page.
PdfPageBase page = loadedDocument.Pages[0];

//Extract text from first page.
string extractedTexts = page.ExtractText(true);

//Close the document.
loadedDocument.Close(true);

Console.WriteLine("Extracted text: " + extractedTexts);
Console.ReadLine();