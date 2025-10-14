using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Gets the first page of the document.
    PdfLoadedPage page = loadedDocument.Pages[0] as PdfLoadedPage;

    //Gets the annotation collection.
    PdfLoadedAnnotationCollection annotations = page.Annotations;

    //Removes the first annotation.
    annotations.RemoveAt(0);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
