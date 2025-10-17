using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the first page from the document
    PdfLoadedPage firstPage = loadedDocument.Pages[0] as PdfLoadedPage;

    //Get the annotation on that page
    PdfLoadedAnnotation annotation = firstPage.Annotations[0] as PdfLoadedAnnotation;

    //Get the annotation creation date.
    DateTime creationDate = annotation.CreationDate;

    Console.WriteLine("Annotation Creation Date: " + creationDate);

}
