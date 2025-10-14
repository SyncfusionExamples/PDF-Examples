using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Creates a new page.
    PdfPage page = document.Pages.Add();

    //Creates a new pdf rubber stamp annotation.
    RectangleF rectangle = new RectangleF(40, 60, 80, 20);

    //Create rubber stamp annotation with some properties. 
    PdfRubberStampAnnotation rubberStampAnnotation = new PdfRubberStampAnnotation(rectangle, " Text Rubber Stamp Annotation");
    rubberStampAnnotation.Icon = PdfRubberStampAnnotationIcon.Draft;
    rubberStampAnnotation.Text = "Text Properties Rubber Stamp Annotation";

    //Adds annotation to the page.
    page.Annotations.Add(rubberStampAnnotation);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}