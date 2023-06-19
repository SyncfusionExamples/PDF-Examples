// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Creates a PDF document.
PdfDocument finalDoc = new PdfDocument();

//Get stream from an existing PDF document. 
FileStream firstPDFStream = new FileStream(Path.GetFullPath("../../../Protected_File1.pdf"), FileMode.Open, FileAccess.Read);
//Load the PDF document.
PdfLoadedDocument firstDocument = new PdfLoadedDocument(firstPDFStream, "Syncfusion");
//Imports the page at 1 from the loaded document.
finalDoc.ImportPageRange(firstDocument, 0, firstDocument.Pages.Count-1);

//Get stream from an existing PDF document. 
FileStream secondPDFStream = new FileStream(Path.GetFullPath("../../../Protected_File2.pdf"), FileMode.Open, FileAccess.Read);
//Load the PDF document.
PdfLoadedDocument secondDocument = new PdfLoadedDocument(secondPDFStream, "Password");
//Imports the page at 1 from the loaded document.
finalDoc.ImportPageRange(secondDocument, 0, secondDocument.Pages.Count - 1);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    finalDoc.Save(outputFileStream);
}

//Close the documents.
firstDocument.Close();
secondDocument.Close();
finalDoc.Close();
