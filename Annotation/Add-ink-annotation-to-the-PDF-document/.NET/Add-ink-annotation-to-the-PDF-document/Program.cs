using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Creates a new page.
    PdfPage page = document.Pages.Add();

    //Create the line points. 
    List<float> linePoints = new List<float> { 40, 300, 60, 100, 40, 50, 40, 300 };

    RectangleF rectangle = new RectangleF(0, 0, 300, 400);

    //Creates a new ink annotation.
    PdfInkAnnotation inkAnnotation = new PdfInkAnnotation(rectangle, linePoints);

    //Set the color of ink annotation. 
    inkAnnotation.Color = new PdfColor(Color.Red);

    //Adds annotation to the page.
    page.Annotations.Add(inkAnnotation);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}