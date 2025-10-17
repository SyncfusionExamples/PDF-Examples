using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Creates a new page.
    PdfPage page = document.Pages.Add();

    RectangleF rectangle = new RectangleF(40, 60, 80, 20);

    //Creates a new PDF rubber stamp annotation.
    PdfRubberStampAnnotation rubberStampAnnotation = new PdfRubberStampAnnotation(rectangle, " Text Rubber Stamp Annotation");
    rubberStampAnnotation.Icon = PdfRubberStampAnnotationIcon.Draft;
    rubberStampAnnotation.Text = "Text Properties Rubber Stamp Annotation";

    //Set the AnnotationFlags to print.
    rubberStampAnnotation.AnnotationFlags = PdfAnnotationFlags.Print;

    //Adds annotation to the page.
    page.Annotations.Add(rubberStampAnnotation);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
