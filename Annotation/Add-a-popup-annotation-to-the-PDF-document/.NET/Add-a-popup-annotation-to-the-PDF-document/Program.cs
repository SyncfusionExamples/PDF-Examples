using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Creates a new page.
    PdfPage page = document.Pages.Add();

    //Creates a rectangle.
    RectangleF rectangle = new RectangleF(10, 40, 30, 30);

    //Creates a new popup annotation.
    PdfPopupAnnotation popupAnnotation = new PdfPopupAnnotation(rectangle, "Test popup annotation");
    popupAnnotation.Border.Width = 4;
    popupAnnotation.Border.HorizontalRadius = 20;
    popupAnnotation.Border.VerticalRadius = 30;

    //Sets the pdf popup icon.
    popupAnnotation.Icon = PdfPopupIcon.NewParagraph;

    //Adds this annotation to the created page.
    page.Annotations.Add(popupAnnotation);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}