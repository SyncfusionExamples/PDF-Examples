using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Creates a new page.
    PdfPage page = document.Pages.Add();

    Syncfusion.Drawing.RectangleF rect = new Syncfusion.Drawing.RectangleF(10, 100, 100, 100);

    //Creates the circle measurement annotation.
    PdfCircleMeasurementAnnotation circleMeasureAnnotation = new PdfCircleMeasurementAnnotation(rect);

    //Assign author to the circle measurement annotation.
    circleMeasureAnnotation.Author = "Syncfusion";

    //Assign subject to the circle measurement annotation.
    circleMeasureAnnotation.Subject = "Circle measurement annotation";

    //Assign color to the square measurement annotation.
    circleMeasureAnnotation.Color = new PdfColor(Syncfusion.Drawing.Color.Red);

    //Assign measurement unit to the circle measurement annotation.
    circleMeasureAnnotation.Unit = PdfMeasurementUnit.Centimeter;

    //Sets the measurementType to the circle measurement annotation.
    circleMeasureAnnotation.MeasurementType = PdfCircleMeasurementType.Diameter;

    //Adds the circle measurement annotation to a page.
    page.Annotations.Add(circleMeasureAnnotation);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
