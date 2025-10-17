using Syncfusion.Pdf;

//Create a PDF document. 
PdfDocument finalDoc = new PdfDocument();
//Get stream from the PDF documents. 
using (FileStream stream1 = new FileStream(Path.GetFullPath(@"Data/File1.pdf"), FileMode.Open, FileAccess.Read))
using (FileStream stream2 = new FileStream(Path.GetFullPath(@"Data/File2.pdf"), FileMode.Open, FileAccess.Read))
{
    //Create a PDF stream for merging. 
    Stream[] streams = { stream1, stream2 };
    PdfMergeOptions mergeOptions = new PdfMergeOptions();

    //Enable the Merge Accessibility Tags. 
    mergeOptions.MergeAccessibilityTags = true;

    //Merge PDFDocument. 
    PdfDocumentBase.Merge(finalDoc, mergeOptions, streams);

    //Save the PDF document
    finalDoc.Save(Path.GetFullPath(@"Output/Output.pdf"));

    //Close the documents.
    finalDoc.Close(true);
}