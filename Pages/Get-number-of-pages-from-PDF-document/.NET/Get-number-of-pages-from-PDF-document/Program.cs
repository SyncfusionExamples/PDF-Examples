// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document.
FileStream inputFileStream = new FileStream(Path.GetFullPath(@"../../../Input.pdf"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputFileStream);

//Get the page count.
int pageCount = loadedDocument.Pages.Count;

//Close the document.
loadedDocument.Close(true);

//Write the number of pages in a PDF document in console window. 
Console.WriteLine("Number of pages in the PDF document is " + pageCount);
Console.ReadLine();