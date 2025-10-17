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
    //Load the first PDF document 
    using (FileStream firstPDFStream = new FileStream(Path.GetFullPath(@"Data/File1.pdf"), FileMode.Open, FileAccess.Read))
    {
        //Load the second PDF document 
        using (FileStream secondPDFStream = new FileStream(Path.GetFullPath(@"Data/File2.pdf"), FileMode.Open, FileAccess.Read))
        {
            //Create a list of streams to merge 
            Stream[] streams = { firstPDFStream, secondPDFStream };
            //Create a merge options object 
            PdfMergeOptions mergeOptions = new PdfMergeOptions();
            //Enable the extend margin option 
            mergeOptions.ExtendMargin = true;
            //Merge the PDF documents  
            PdfDocumentBase.Merge(outputDocument, mergeOptions, streams);
            //Save the document
            outputDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
        }
}
