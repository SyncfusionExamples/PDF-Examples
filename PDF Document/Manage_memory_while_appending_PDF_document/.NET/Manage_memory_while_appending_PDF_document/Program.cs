using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/File1.pdf"));

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Enable memory optimization.
document.EnableMemoryOptimization = true;

//Append the document with source document.
document.Append(loadedDocument);

//Save the PDF document
document.Save(Path.GetFullPath(@"Output/Output.pdf"));

//Close the document
document.Close(true);
loadedDocument.Close(true);

