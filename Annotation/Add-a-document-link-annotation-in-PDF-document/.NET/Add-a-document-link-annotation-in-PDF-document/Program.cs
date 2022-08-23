// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Creates a new PDF document.
PdfDocument document = new PdfDocument();

//Creates a new page.
PdfPage page = document.Pages.Add();

//Creates a page.
PdfPage page2 = document.Pages.Add();

//Creates a new rectangle.
RectangleF docLinkAnnotationRectangle = new RectangleF(10, 40, 30, 30);

//Creates a new document link annotation.
PdfDocumentLinkAnnotation documentLinkAnnotation = new PdfDocumentLinkAnnotation(docLinkAnnotationRectangle);
documentLinkAnnotation.AnnotationFlags = PdfAnnotationFlags.NoRotate;
documentLinkAnnotation.Text = "Document link annotation";
documentLinkAnnotation.Color = new PdfColor(Color.Navy);

//Sets the destination.
documentLinkAnnotation.Destination = new PdfDestination(page2);
documentLinkAnnotation.Destination.Location = new PointF(10, 0);
documentLinkAnnotation.Destination.Zoom = 5;

//Adds this annotation to a new page.
page.Annotations.Add(documentLinkAnnotation);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
