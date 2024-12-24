using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;

// Load the PDF document
using (FileStream inputStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
{
    using (PdfLoadedDocument document = new PdfLoadedDocument(inputStream))
    {

        //Get the first page from the document
        PdfLoadedPage firstPage = document.Pages[0] as PdfLoadedPage;

        //Get the annotation on that page
        PdfLoadedAnnotation annotation = firstPage.Annotations[0] as PdfLoadedAnnotation;

        //Get the annotation creation date.
        DateTime creationDate = annotation.CreationDate;

        Console.WriteLine("Annotation Creation Date: " + creationDate);
    }
}
