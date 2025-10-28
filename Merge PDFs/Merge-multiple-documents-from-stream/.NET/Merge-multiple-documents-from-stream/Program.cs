using Syncfusion.Pdf;

//Creates a new PDF document
using (PdfDocument document = new PdfDocument())
{
    //Creates a string array of source files to be merged
    string[] source = { Path.GetFullPath(@"Data/file1.pdf"), Path.GetFullPath(@"Data/file2.pdf") };
    //Merge PDF documents
    PdfDocument.Merge(document, source);
    //Saves the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}