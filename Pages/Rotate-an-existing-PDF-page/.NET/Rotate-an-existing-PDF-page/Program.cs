// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Get file stream from an existing PDF document.
FileStream inputFileStream = new FileStream(Path.GetFullPath(@"../../../Input.pdf"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputFileStream);

//Gets the page.
PdfPageBase loadedPage = loadedDocument.Pages[0] as PdfPageBase;

//Set the rotation for loaded page.
loadedPage.Rotation = PdfPageRotateAngle.RotateAngle90;

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
