using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a new page
    PdfPage page = document.Pages.Add();
    // create a new ellipse annotation
    PdfEllipseAnnotation annotation = new PdfEllipseAnnotation(new RectangleF(0, 0, 200, 100), "Ellipse");
    //Assign the border width
    annotation.Border.BorderWidth = 1;
    //Assign the color
    annotation.Color = Color.Red;
    //Assign the InnerColor
    annotation.InnerColor = Color.Blue;
    //Create a new PdfBorderEffect class
    PdfBorderEffect bordereffect = new PdfBorderEffect();
    //Assign the intensity value
    bordereffect.Intensity = 2;
    //Assign the cloud style
    bordereffect.Style = PdfBorderEffectStyle.Cloudy;
    //Assign the BorderEffect
    annotation.BorderEffect = bordereffect;
    //Set appearance for the annotation.
    annotation.SetAppearance(true);
    // Adds the annotation to the page.
    page.Annotations.Add(annotation);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
