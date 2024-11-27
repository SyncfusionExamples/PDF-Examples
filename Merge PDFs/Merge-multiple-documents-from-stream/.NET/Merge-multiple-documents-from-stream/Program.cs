// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;

//Create a PDF document 
using (PdfDocument finalDocument = new PdfDocument()) 
{ 
    //Get the stream from an existing PDF document 
    using (FileStream firstStream = new FileStream(Path.GetFullPath(@"Data/file1.pdf"), FileMode.Open, FileAccess.Read)) 
    using (FileStream secondStream = new FileStream(Path.GetFullPath(@"Data/file2.pdf"), FileMode.Open, FileAccess.Read)) 
    { 
        //Create a PDF stream for merging 
        Stream[] streams = { firstStream, secondStream }; 
        //Merge PDF documents 
        PdfDocumentBase.Merge(finalDocument, streams); 
        //Save the document into a stream 
        using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
        { 
            finalDocument.Save(outputFileStream); 
        } 
    } 
}

