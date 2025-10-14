using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Import annotation data from FDF stream
    FileStream jsonStream = new FileStream("Annotations.Json", FileMode.Open, FileAccess.Read);
    loadedDocument.ImportAnnotations(jsonStream, AnnotationDataFormat.Json);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}