using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Create a new PDF page.
    PdfPage page = document.Pages.Add();

    //Creates a new rectangle.
    RectangleF rectangle = new RectangleF(10, 40, 30, 30);

    //Creates a new popup annotation with some properties.
    PdfPopupAnnotation popupAnnotation = new PdfPopupAnnotation(rectangle, "Test popup annotation");
    popupAnnotation.Border.Width = 4;
    popupAnnotation.Border.HorizontalRadius = 20;
    popupAnnotation.Border.VerticalRadius = 30;

    //Sets the PDF popup icon.
    popupAnnotation.Icon = PdfPopupIcon.NewParagraph;

    //Adds this annotation to a new page.
    page.Annotations.Add(popupAnnotation);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
