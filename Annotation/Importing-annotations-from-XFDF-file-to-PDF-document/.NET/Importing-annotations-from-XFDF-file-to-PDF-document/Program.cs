// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Get stream from the XFDF file. 
FileStream xfdfStream = new FileStream(Path.GetFullPath("../../../Annotations.xfdf"), FileMode.Open, FileAccess.Read);

//Import annotations from XFDF file to PDF document. 
loadedDocument.ImportAnnotations(xfdfStream, AnnotationDataFormat.XFdf);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);