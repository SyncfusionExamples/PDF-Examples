
using Syncfusion.Pdf;

//Generate the PDF document.
PdfDocument finalDoc = new PdfDocument();
FileStream stream1 = new FileStream("../../../Data/File1.pdf", FileMode.Open, FileAccess.Read);
FileStream stream2 = new FileStream("../../../Data/File2.pdf", FileMode.Open, FileAccess.Read);
// Creates a PDF stream for merging.
Stream[] streams = { stream1, stream2 };
// Merges PDFDocument.
PdfDocumentBase.Merge(finalDoc, streams);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    finalDoc.Save(outputFileStream);
}
//Close the document.
finalDoc.Close(true);
