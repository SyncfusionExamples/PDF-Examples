using Syncfusion.Pdf.Parsing;

//Loads the document
PdfLoadedDocument lDoc = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf"));
//Export annotation data to XFDF file
lDoc.ExportAnnotations("Annotations.xfdf", AnnotationDataFormat.XFdf);
//Close the document
lDoc.Close(true);