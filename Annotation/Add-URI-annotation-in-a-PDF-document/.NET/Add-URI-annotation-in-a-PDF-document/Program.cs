using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Creates a new page.
    PdfPage page = document.Pages.Add();

    //Creates a new rectangle.
    RectangleF rectangle = new RectangleF(10, 40, 30, 30);

    //Creates a new Uri Annotation.
    PdfUriAnnotation uriAnnotation = new PdfUriAnnotation(rectangle, "http://www.google.com");

    //Sets Text to uriAnnotation.
    uriAnnotation.Text = "Uri Annotation";

    //Adds this annotation to a new page.
    page.Annotations.Add(uriAnnotation);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
};

