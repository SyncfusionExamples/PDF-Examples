using Syncfusion.Pdf.Parsing;

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf"));

//Load the existing form.
PdfLoadedForm loadedForm = loadedDocument.Form;

//Import the FDF stream.
loadedForm.ImportDataFDF(Path.GetFullPath(@"Data/Input.fdf"), true);

//Save the PDF document.
loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));

//Close the PDF document. 
loadedDocument.Close(true);