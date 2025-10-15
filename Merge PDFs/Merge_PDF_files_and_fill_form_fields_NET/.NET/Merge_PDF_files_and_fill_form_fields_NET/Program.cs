using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;
using System.Reflection.Metadata;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
PdfDocument finalDocument = new PdfDocument();

//Get the stream from an existing PDF documents.
FileStream stream1 = new FileStream(Path.GetFullPath(@"Data/File1.pdf"), FileMode.Open, FileAccess.Read);
FileStream stream2 = new FileStream(Path.GetFullPath(@"Data/File2.pdf"), FileMode.Open, FileAccess.Read);
//Creates a PDF stream for merging.
Stream[] streams = { stream1, stream2 };
//Merges PDFDocument.
PdfDocumentBase.Merge(finalDocument, streams);

//Get the form. 
PdfForm loadedForm = finalDocument.Form;
loadedForm.SetDefaultAppearance(false);

//Get the loaded text box field and fill it.
PdfLoadedTextBoxField loadedTextBoxField = loadedForm.Fields[0] as PdfLoadedTextBoxField;
loadedTextBoxField.Text = "John";

//Get the loaded text box field and fill it.
PdfLoadedTextBoxField loadedTextBoxField1 = loadedForm.Fields[1] as PdfLoadedTextBoxField;
loadedTextBoxField1.Text = "Smith";

//Get the loaded text box field and fill it.
PdfLoadedTextBoxField loadedTextBoxField2 = loadedForm.Fields[4] as PdfLoadedTextBoxField;
loadedTextBoxField2.Text = "SSN0001";

//Save the PDF document
finalDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));

//Close the document
finalDocument.Close(true);

