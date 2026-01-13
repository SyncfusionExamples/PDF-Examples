using Syncfusion.Pdf;

//Create a PDF document. 
PdfDocument finalDoc = new PdfDocument();
//Creates a string array of source files to be merged.
string[] source = { Path.GetFullPath(@"Data/File1.pdf"), Path.GetFullPath(@"Data/File2.pdf") };
PdfMergeOptions mergeOptions = new PdfMergeOptions();

//Enable the Merge Accessibility Tags. 
mergeOptions.MergeAccessibilityTags = true;

//Merge PDFDocument. 
PdfDocumentBase.Merge(finalDoc, mergeOptions, source);

//Save the PDF document
finalDoc.Save(Path.GetFullPath(@"Output/Output.pdf"));

//Close the documents.
finalDoc.Close(true);
