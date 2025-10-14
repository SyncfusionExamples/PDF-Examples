using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Specify the annotation types to flatten
    PdfLoadedAnnotationType[] pdfLoadedAnnotationTypes = new PdfLoadedAnnotationType[]
    {
            PdfLoadedAnnotationType.PolygonAnnotation
    };

    //Flatten the selected annotations
    loadedDocument.FlattenAnnotations(pdfLoadedAnnotationTypes);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}