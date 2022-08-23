// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Creates a new PDF document.
PdfDocument document = new PdfDocument();

//Creates a new page.
PdfPage page = document.Pages.Add();

//Create the font. 
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 10f, PdfFontStyle.Regular);

//Specifies the line end points.
int[] points = new int[] { 100, 750, 500, 750 };

//Creates the line measurement annotation.
PdfLineMeasurementAnnotation lineMeasureAnnotation = new PdfLineMeasurementAnnotation(points);

//Assign author to the line measurement annotation.
lineMeasureAnnotation.Author = "Syncfusion";

//Assign subject to the line measurement annotation.
lineMeasureAnnotation.Subject = "LineAnnotation";

//Assign unit to the line measurement annotation.
lineMeasureAnnotation.Unit = PdfMeasurementUnit.Inch;

//Assign borderWidth to the line measurement annotation.
lineMeasureAnnotation.lineBorder.BorderWidth = 2;

//Assign font to the line measurement annotation.
lineMeasureAnnotation.Font = font;

//Assign color to the line measurement annotation.
lineMeasureAnnotation.Color = new PdfColor(Syncfusion.Drawing.Color.Red);

//Adds the line measurement annotation to a new page.
page.Annotations.Add(lineMeasureAnnotation);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
