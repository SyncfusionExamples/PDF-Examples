// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

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

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
	//Save the PDF document to file stream.
	loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);