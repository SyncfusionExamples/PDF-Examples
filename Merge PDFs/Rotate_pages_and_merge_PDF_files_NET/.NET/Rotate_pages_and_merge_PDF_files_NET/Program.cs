using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;
using System.Reflection.Metadata;

//Create a new PDF document
PdfDocument finalDocument = new PdfDocument();

//Load the PDF document.
PdfLoadedDocument loadedDocument1 = new PdfLoadedDocument(Path.GetFullPath(@"Data/File1.pdf"));
//Gets the page
PdfPageBase loadedPage1 = loadedDocument1.Pages[0] as PdfPageBase;
//Set the rotation for loaded page.
loadedPage1.Rotation = PdfPageRotateAngle.RotateAngle90;
//Imports the page at 1 from the loaded document.
finalDocument.ImportPageRange(loadedDocument1, 0, loadedDocument1.Pages.Count - 1);

//Load the PDF document
FileStream docStream2 = new FileStream(Path.GetFullPath(@"Data/File2.pdf"), FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument2 = new PdfLoadedDocument(docStream2);
//Gets the page
PdfPageBase loadedPage2 = loadedDocument2.Pages[1] as PdfPageBase;
//Set the rotation for loaded page
loadedPage2.Rotation = PdfPageRotateAngle.RotateAngle270;
//Imports the page at 1 from the loaded document
finalDocument.ImportPageRange(loadedDocument2, 0, loadedDocument2.Pages.Count - 1);

//Save the PDF document
finalDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));

//Close the document
finalDocument.Close(true);
