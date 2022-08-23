// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Load an existing form. 
PdfLoadedForm loadedForm = loadedDocument.Form;

//Create memory stream.
MemoryStream ms = new MemoryStream();

//Load the FDF file. 
FileStream stream1 = new FileStream(Path.GetFullPath("../../../Export.fdf"), FileMode.Create, FileAccess.ReadWrite);

//Export the existing PDF document to FDF file. 
loadedForm.ExportData(stream1, DataFormat.Fdf, "AcroForm1");

//Close the document.
loadedDocument.Close(true);

