// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Import annotation data from FDF stream.
FileStream fdfStream = new FileStream(Path.GetFullPath("../../../Annotations.fdf"), FileMode.Open, FileAccess.Read);

//Import annotations from FDF file to PDF document. 
loadedDocument.ImportAnnotations(fdfStream, AnnotationDataFormat.Fdf);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
