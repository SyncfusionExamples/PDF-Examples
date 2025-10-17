using Syncfusion.Pdf.Parsing;

//Loads the document 
PdfLoadedDocument lDoc = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")); 
//Export the annotation data to the JSON file 
lDoc.ExportAnnotations("Annotations.Json", AnnotationDataFormat.Json); 
//Close the document 
lDoc.Close(true);