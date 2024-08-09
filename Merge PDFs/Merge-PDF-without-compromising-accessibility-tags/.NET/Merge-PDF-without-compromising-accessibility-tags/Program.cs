using Syncfusion.Pdf;

//Create a PDF document. 
PdfDocument finalDoc = new PdfDocument();
//Get stream from the PDF documents. 
FileStream stream1 = new FileStream(Path.GetFullPath(@"Data/File1.pdf"), FileMode.Open, FileAccess.Read);
FileStream stream2 = new FileStream(Path.GetFullPath(@"Data/File2.pdf"), FileMode.Open, FileAccess.Read);

//Create a PDF stream for merging. 
Stream[] streams = { stream1, stream2 };
PdfMergeOptions mergeOptions = new PdfMergeOptions();

//Enable the Merge Accessibility Tags. 
mergeOptions.MergeAccessibilityTags = true;

//Merge PDFDocument. 
PdfDocumentBase.Merge(finalDoc, mergeOptions, streams);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    finalDoc.Save(outputFileStream);
}

//Close the documents.
finalDoc.Close(true);

//Dispose the stream. 
stream1.Dispose();
stream2.Dispose();