// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Create a new page.
PdfPage page = document.Pages.Add();

//Create a new rectangle.
RectangleF docLinkAnnotationBounds = new RectangleF(10, 40, 30, 30);

//Create a new document link annotation.
PdfDocumentLinkAnnotation documentLinkAnnotation = new PdfDocumentLinkAnnotation(docLinkAnnotationBounds);

//Set the annotation flags.
documentLinkAnnotation.AnnotationFlags = PdfAnnotationFlags.NoRotate;

//Set the annotation text.
documentLinkAnnotation.Text = "Document link annotation";

//Set the annotation's color.
documentLinkAnnotation.Color = new PdfColor(Color.Navy);

//Creates another page.
PdfPage navigationPage = document.Pages.Add();

//Set the destination.
documentLinkAnnotation.Destination = new PdfDestination(navigationPage);

//Set the document link annotation location.
documentLinkAnnotation.Destination.Location = new PointF(10, 0);

//Set the document annotation zoom level.
documentLinkAnnotation.Destination.Zoom = 5;

//Add this annotation to a new page.
page.Annotations.Add(documentLinkAnnotation);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);