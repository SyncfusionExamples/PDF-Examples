//Load the PDF document 
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

FileStream docStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.ReadWrite);
PdfLoadedDocument lDoc = new PdfLoadedDocument(docStream);

//Import annotation data from XFDF stream
FileStream xfdfStream = new FileStream(Path.GetFullPath(@"Data/Annotations.xfdf"), FileMode.Open, FileAccess.Read);
lDoc.ImportAnnotations(xfdfStream, AnnotationDataFormat.XFdf);

//Save the document into stream
MemoryStream stream = new MemoryStream();
lDoc.Save(stream);

PdfLoadedDocument loadedDocument = new PdfLoadedDocument(stream);
foreach (PdfLoadedPage pages in loadedDocument.Pages)
{
    foreach (PdfLoadedAnnotation annot in pages.Annotations)
        annot.SetAppearance(true);
}
//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}
//Closes the document 
lDoc.Close(true);
loadedDocument.Close(true);
