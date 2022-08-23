// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Creates a new pdf document.
PdfDocument document = new PdfDocument();

//Creates a new page.
PdfPage page = document.Pages.Add();

//Creates PDF free text annotation.
PdfFreeTextAnnotation freeText = new PdfFreeTextAnnotation(new RectangleF(50, 100, 100, 50));

//Sets properties to the annotation.
freeText.MarkupText = "Free Text with Callout";
freeText.TextMarkupColor = new PdfColor(Color.Black);
freeText.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 7f);
freeText.Color = new PdfColor(Color.Yellow);
freeText.BorderColor = new PdfColor(Color.Red);
freeText.Border = new PdfAnnotationBorder(.5f);
freeText.LineEndingStyle = PdfLineEndingStyle.OpenArrow;
freeText.AnnotationFlags = PdfAnnotationFlags.Default;
freeText.Text = "Free Text";
freeText.Opacity = 0.5f;
PointF[] points = { new PointF(100, 450), new PointF(100, 200), new PointF(100, 150) };
freeText.CalloutLines = points;

//Adds the annotation to page.
page.Annotations.Add(freeText);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);