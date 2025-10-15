using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Creates a PDF document.
PdfDocument finalDoc = new PdfDocument();

//Load the PDF document.
PdfLoadedDocument firstDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Protected_File1.pdf"), "Syncfusion");
//Imports the page at 1 from the loaded document.
finalDoc.ImportPageRange(firstDocument, 0, firstDocument.Pages.Count-1);

//Load the PDF document.
PdfLoadedDocument secondDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Protected_File2.pdf"), "Password");
//Imports the page at 1 from the loaded document.
finalDoc.ImportPageRange(secondDocument, 0, secondDocument.Pages.Count - 1);

//Save the PDF document
finalDoc.Save(Path.GetFullPath(@"Output/Output.pdf"));


//Close the documents.
firstDocument.Close();
secondDocument.Close();
finalDoc.Close();
