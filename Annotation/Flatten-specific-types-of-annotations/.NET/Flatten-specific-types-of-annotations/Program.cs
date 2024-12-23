using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document using a file stream
using (FileStream docStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
{
    //Load the existing PDF document
    using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream))
    {
        //Specify the annotation types to flatten
        PdfLoadedAnnotationType[] pdfLoadedAnnotationTypes = new PdfLoadedAnnotationType[]
        {
            PdfLoadedAnnotationType.PolygonAnnotation
        };

        //Flatten the selected annotations
        loadedDocument.FlattenAnnotations(pdfLoadedAnnotationTypes);

        //Save the flattened document using a file stream
        using (FileStream outputStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.Write))
        {
            loadedDocument.Save(outputStream);
        }
    }
}