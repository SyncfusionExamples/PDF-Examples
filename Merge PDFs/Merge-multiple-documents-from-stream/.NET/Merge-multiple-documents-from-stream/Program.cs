using Syncfusion.Pdf;

//Creates a PDF document.
using (PdfDocument document = new PdfDocument())
{
    using FileStream stream1 = new FileStream(Path.GetFullPath(@"Data/file1.pdf"), FileMode.Open, FileAccess.Read);
    using FileStream stream2 = new FileStream(Path.GetFullPath(@"Data/file2.pdf"), FileMode.Open, FileAccess.Read);
    //Creates a PDF stream for merging.
    Stream[] streams = { stream1, stream2 };
    //Merges PDFDocument.
    PdfDocumentBase.Merge(document, streams);
    //Save the merged document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}