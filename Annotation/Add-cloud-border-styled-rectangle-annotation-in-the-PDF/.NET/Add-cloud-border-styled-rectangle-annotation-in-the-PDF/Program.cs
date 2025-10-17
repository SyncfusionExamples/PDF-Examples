using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Create a new page.
    PdfPage page = document.Pages.Add();

    //Create a rectangle annotation.
    PdfRectangleAnnotation annotation = new PdfRectangleAnnotation(new RectangleF(0, 0, 200, 100), "rectangle");

    //Assign the borderWidth value.
    annotation.Border.BorderWidth = 1;

    //Assign the color.
    annotation.Color = Color.Red;

    //Assign the InnerColor.
    annotation.InnerColor = Color.Blue;

    //Create a new PdfBorderEffect class.
    PdfBorderEffect bordereffect = new PdfBorderEffect();

    //Assign the intensity value.
    bordereffect.Intensity = 2;

    //Assign the cloud style.
    bordereffect.Style = PdfBorderEffectStyle.Cloudy;

    //Assign the BorderEffect.
    annotation.BorderEffect = bordereffect;

    //Adds the annotation to the page.
    page.Annotations.Add(annotation);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
