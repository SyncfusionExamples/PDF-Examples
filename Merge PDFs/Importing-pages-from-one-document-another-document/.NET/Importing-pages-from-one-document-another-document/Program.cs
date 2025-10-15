using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf"));

//Creates a new document.
PdfDocument document = new PdfDocument();

//Imports the page at 1 from the loaded document.
document.ImportPage(loadedDocument, 1);

//Save the PDF document
document.Save(Path.GetFullPath(@"Output/Output.pdf"));

//Close the documents.
loadedDocument.Close();
document.Close();
