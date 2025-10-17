using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Creates a new page.
    PdfPage page = document.Pages.Add();

    Syncfusion.Drawing.RectangleF rect = new Syncfusion.Drawing.RectangleF(10, 100, 100, 100);

    //Creates the square measurement annotation.
    PdfSquareMeasurementAnnotation squareMeasureAnnotation = new PdfSquareMeasurementAnnotation(rect);

    //Assign author to the square measurement annotation.
    squareMeasureAnnotation.Author = "Syncfusion";

    //Assign subject to the square measurement annotation.
    squareMeasureAnnotation.Subject = "Square measurement annotation";

    //Assign color to the square measurement annotation.
    squareMeasureAnnotation.Color = new PdfColor(Syncfusion.Drawing.Color.Red);

    //Assign measurement unit to the square measurement annotation.
    squareMeasureAnnotation.Unit = PdfMeasurementUnit.Centimeter;

    //Adds the square measurement annotation to a page.
    page.Annotations.Add(squareMeasureAnnotation);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
