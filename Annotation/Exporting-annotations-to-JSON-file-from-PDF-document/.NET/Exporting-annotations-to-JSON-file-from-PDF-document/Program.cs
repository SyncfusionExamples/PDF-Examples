// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Export the annotation data from the JSON stream.
Stream jsonStream = new MemoryStream();

//Export annotations to JSON file from PDF document. 
loadedDocument.ExportAnnotations(jsonStream, AnnotationDataFormat.Json);

//Close the document.
loadedDocument.Close(true);

jsonStream.Position = 0;

//Create file stream. 
FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.json"), FileMode.Create, FileAccess.ReadWrite);

//Copy the memory stream to file stream. 
jsonStream.CopyTo(outputFileStream);

//Dispose the stream. 
jsonStream.Dispose();
outputFileStream.Dispose();