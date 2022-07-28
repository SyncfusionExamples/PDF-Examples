// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document.
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Load the first page.
PdfPageBase page = loadedDocument.Pages[0];

//Extract text from first page.
string extractedText = page.ExtractText();

//Close the document.
loadedDocument.Close(true);

//Write the extracted lines in console window. 
Console.WriteLine("Extracted Text: " + extractedText);
Console.ReadLine();
