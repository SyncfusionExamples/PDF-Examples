// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream1 = new FileStream(Path.GetFullPath("../../../File1.pdf"), FileMode.Open, FileAccess.Read);

//Load the first PDF document.
PdfLoadedDocument loadedDocument1 = new PdfLoadedDocument(docStream1);

//Get stream from an existing PDF document. 
FileStream docStream2 = new FileStream(Path.GetFullPath("../../../File2.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document.
PdfLoadedDocument loadedDocument2 = new PdfLoadedDocument(docStream2);

//Creates the new document.
PdfDocument document = new PdfDocument();

//Imports and arranges the pages.
document.ImportPage(loadedDocument1, 1);
document.ImportPage(loadedDocument2, 0);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);