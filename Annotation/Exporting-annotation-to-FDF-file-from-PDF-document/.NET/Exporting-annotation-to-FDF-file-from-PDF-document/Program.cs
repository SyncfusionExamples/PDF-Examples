// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Export annotation data from FDF stream.
Stream fdfStream = new MemoryStream();

//Export annotation to FDF file from PDF document. 
loadedDocument.ExportAnnotations(fdfStream, AnnotationDataFormat.Fdf);

//Close the document
loadedDocument.Close(true);

fdfStream.Position = 0;

//Create file stream.
FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.fdf"), FileMode.Create, FileAccess.ReadWrite);

//Copy the memory stream to file stream. 
fdfStream.CopyTo(outputFileStream);

//dispose the streams. 
fdfStream.Dispose();
outputFileStream.Dispose();