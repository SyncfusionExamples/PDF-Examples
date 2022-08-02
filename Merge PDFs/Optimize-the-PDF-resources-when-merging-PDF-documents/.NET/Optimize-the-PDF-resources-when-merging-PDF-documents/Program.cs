// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;

//Creates a PDF document.
PdfDocument finalDoc = new PdfDocument();

//Get stream from an existing PDF documents. 
FileStream stream1 = new FileStream(Path.GetFullPath("../../../File1.pdf"), FileMode.Open, FileAccess.Read);
FileStream stream2 = new FileStream(Path.GetFullPath("../../../File2.pdf"), FileMode.Open, FileAccess.Read);

//Creates a PDF stream for merging.
Stream[] streams = { stream1, stream2 };

//Create the merge option. 
PdfMergeOptions mergeOptions = new PdfMergeOptions();

//Enable Optimize Resources
mergeOptions.OptimizeResources = true;

//Merges PDFDocument
PdfDocumentBase.Merge(finalDoc, mergeOptions, streams);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    finalDoc.Save(outputFileStream);
}

//Close the document.
finalDoc.Close(true);