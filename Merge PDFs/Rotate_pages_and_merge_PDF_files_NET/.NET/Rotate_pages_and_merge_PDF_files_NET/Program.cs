// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;
using System.Reflection.Metadata;

//Create a new PDF document
PdfDocument finalDocument = new PdfDocument();

//Load the PDF document.
FileStream docStream1 = new FileStream(Path.GetFullPath("../../../File1.pdf"), FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument1 = new PdfLoadedDocument(docStream1);
//Gets the page
PdfPageBase loadedPage1 = loadedDocument1.Pages[0] as PdfPageBase;
//Set the rotation for loaded page.
loadedPage1.Rotation = PdfPageRotateAngle.RotateAngle90;
//Imports the page at 1 from the loaded document.
finalDocument.ImportPageRange(loadedDocument1, 0, loadedDocument1.Pages.Count - 1);

//Load the PDF document
FileStream docStream2 = new FileStream(Path.GetFullPath("../../../File2.pdf"), FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument2 = new PdfLoadedDocument(docStream2);
//Gets the page
PdfPageBase loadedPage2 = loadedDocument2.Pages[1] as PdfPageBase;
//Set the rotation for loaded page
loadedPage2.Rotation = PdfPageRotateAngle.RotateAngle270;
//Imports the page at 1 from the loaded document
finalDocument.ImportPageRange(loadedDocument2, 0, loadedDocument2.Pages.Count - 1);

//Create file stream
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream
    finalDocument.Save(outputFileStream);
}

//Close the document
finalDocument.Close(true);
