// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument lDoc = new PdfLoadedDocument(docStream);

//Export annotation data from XFDF stream.
Stream xfdfStream = new MemoryStream();

//Export annotations to XFDF file from PDF document. 
lDoc.ExportAnnotations(xfdfStream, AnnotationDataFormat.XFdf);

//Close the document
lDoc.Close(true);

xfdfStream.Position = 0;

//Create file stream.
FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.xfdf"), FileMode.Create, FileAccess.ReadWrite);

//Copy memory stream to file stream. 
xfdfStream.CopyTo(outputFileStream);

//Dispose the streams. 
xfdfStream.Dispose();
outputFileStream.Dispose();