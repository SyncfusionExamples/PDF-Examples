using Syncfusion.Pdf;

//Creates a PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Creates a string array of source files to be merged.
    string[] source = { Path.GetFullPath(@"Data/file1.pdf"), Path.GetFullPath(@"Data/file2.pdf") };
    //Merges PDFDocument.
    PdfDocumentBase.Merge(document, source);
    //Save the merged document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
    document.Close(true);
}