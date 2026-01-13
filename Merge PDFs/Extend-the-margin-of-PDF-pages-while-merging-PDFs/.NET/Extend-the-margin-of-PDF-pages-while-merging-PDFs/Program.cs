using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document 
using (PdfDocument outputDocument = new PdfDocument())
{
    //Create a new instance for the document margin 
    PdfMargins documentMargins = new PdfMargins();
    //Set the margin to 50 points on all sides  
    documentMargins.All = 50;
    //Set the document margins 
    outputDocument.PageSettings.Margins = documentMargins;
    //Creates a string array of source files to be merged.
    string[] source = { Path.GetFullPath(@"Data/File1.pdf"), Path.GetFullPath(@"Data/File2.pdf") };
    //Create a merge options object 
    PdfMergeOptions mergeOptions = new PdfMergeOptions();
    //Enable the extend margin option 
    mergeOptions.ExtendMargin = true;
    //Merge the PDF documents  
    PdfDocumentBase.Merge(outputDocument, mergeOptions, source);
    //Save the document
    outputDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
    outputDocument.Close(true);  
}
