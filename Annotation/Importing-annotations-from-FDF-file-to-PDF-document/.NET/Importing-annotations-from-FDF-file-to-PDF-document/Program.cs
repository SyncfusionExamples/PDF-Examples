using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Import annotation data from FDF stream
    FileStream fdfStream = new FileStream("Annotations.fdf", FileMode.Open, FileAccess.Read);
    loadedDocument.ImportAnnotations(fdfStream, AnnotationDataFormat.Fdf);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
