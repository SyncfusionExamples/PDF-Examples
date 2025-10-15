using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Load the page.
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

    //Create a new rectangle.
    RectangleF docLinkAnnotationBounds = new RectangleF(10, 40, 30, 30);

    //Create a new document link annotation.
    PdfDocumentLinkAnnotation documentLinkAnnotation = new PdfDocumentLinkAnnotation(docLinkAnnotationBounds);

    //Set the annotation text.
    documentLinkAnnotation.Text = "Document link annotation";

    //Set the existing page for navigation.
    PdfLoadedPage navigationPage = loadedDocument.Pages[1] as PdfLoadedPage;

    //Set the pdf destination.
    documentLinkAnnotation.Destination = new PdfDestination(navigationPage);

    //Set the document link annotation location.
    documentLinkAnnotation.Destination.Location = new PointF(10, 0);

    //Add this annotation to respective page.
    loadedPage.Annotations.Add(documentLinkAnnotation);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}