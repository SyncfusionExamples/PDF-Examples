// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;

//Creates a PDF document.
PdfDocument finalDoc = new PdfDocument();

//Get stream from the PDF documents. 
FileStream stream1 = new FileStream(Path.GetFullPath("../../../file1.pdf"), FileMode.Open, FileAccess.Read);
FileStream stream2 = new FileStream(Path.GetFullPath("../../../file2.pdf"), FileMode.Open, FileAccess.Read);

//Creates a PDF stream for merging.
Stream[] streams = { stream1, stream2 };

//Merges documents.
PdfDocumentBase.Merge(finalDoc, streams);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    finalDoc.Save(outputFileStream);
}

//Close the document.
finalDoc.Close();

