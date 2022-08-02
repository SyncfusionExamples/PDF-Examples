// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Create a PDF document.
PdfLoadedDocument lDoc = new PdfLoadedDocument(docStream);

//Create a new document.
PdfDocument document = new PdfDocument();

//Enable memory optimization.
document.EnableMemoryOptimization = true;

//Import the page at 1 from the lDoc.
document.ImportPageRange(lDoc, 0, 1);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
