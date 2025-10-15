using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Create a PDF document.
PdfLoadedDocument lDoc = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf"));

//Create a new document.
PdfDocument document = new PdfDocument();

//Enable memory optimization.
document.EnableMemoryOptimization = true;

//Import the page at 1 from the lDoc.
document.ImportPageRange(lDoc, 0, 1);

//Save the PDF document
document.Save(Path.GetFullPath(@"Output/Output.pdf"));

//Close the document.
document.Close(true);
lDoc.Close(true);
