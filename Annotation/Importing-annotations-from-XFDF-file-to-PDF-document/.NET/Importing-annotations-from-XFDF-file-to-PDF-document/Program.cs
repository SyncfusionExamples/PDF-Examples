using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Import annotation data from FDF stream
    FileStream xfdfStream = new FileStream("Annotations.xfdf", FileMode.Open, FileAccess.Read);
    loadedDocument.ImportAnnotations(xfdfStream, AnnotationDataFormat.XFdf);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}