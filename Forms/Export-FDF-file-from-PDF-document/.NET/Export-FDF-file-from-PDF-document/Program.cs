using Syncfusion.Pdf.Parsing;

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf");

//Load an existing form. 
PdfLoadedForm loadedForm = loadedDocument.Form;

//Export the existing PDF document to FDF file. 
loadedForm.ExportData(Path.GetFullPath("Output/Output.fdf", DataFormat.Fdf, "AcroForm1");

//Close the document.
loadedDocument.Close(true);

