// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document.
FileStream inputFileStream = new FileStream(Path.GetFullPath(@"../../../Input.pdf"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputFileStream);

//Gets the page.
PdfPageBase loadedPage = loadedDocument.Pages[0] as PdfPageBase;

//Get the page is blank or not.
bool isEmpty = loadedPage.IsBlank;

//Check whether page is blank or not. 
if (isEmpty)
{
    Console.WriteLine("The page is blank");
}
else
{
    Console.WriteLine("The page is not blank");
}

//Close the document.
loadedDocument.Close(true);

