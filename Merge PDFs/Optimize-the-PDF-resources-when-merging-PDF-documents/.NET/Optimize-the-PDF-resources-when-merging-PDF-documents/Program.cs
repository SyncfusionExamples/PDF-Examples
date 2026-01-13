using Syncfusion.Pdf;

//Create a new PDF document 
using (PdfDocument outputDocument = new PdfDocument()) 
{ 
   //Creates a string array of source files to be merged.
   string[] source = { Path.GetFullPath(@"Data/File1.pdf"), Path.GetFullPath(@"Data/File2.pdf") };
   //Create a merge options object 
   PdfMergeOptions mergeOptions = new PdfMergeOptions(); 
   //Enable the optimize resources option 
   mergeOptions.OptimizeResources = true; 
   //Merge the PDF documents  
   PdfDocumentBase.Merge(outputDocument, mergeOptions, source); 
   //Save the document
   outputDocument.Save(Path.GetFullPath(@"Output/Output.pdf")); 
   outputDocument.Close();
}