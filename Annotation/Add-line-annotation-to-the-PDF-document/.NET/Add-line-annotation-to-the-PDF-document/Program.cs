// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Creates a new PDF document.
PdfDocument document = new PdfDocument();

//Creates a new page.
PdfPage page = document.Pages.Add();

//Specifies the line end points.
int[] points = new int[] { 80, 420, 150, 420 };

//Creates a new line annotation.
PdfLineAnnotation lineAnnotation = new PdfLineAnnotation(points, "Line Annotation");

//Creates pdf line border.
LineBorder lineBorder = new LineBorder();
lineBorder.BorderStyle = PdfBorderStyle.Solid;
lineBorder.BorderWidth = 1;
lineAnnotation.lineBorder = lineBorder;
lineAnnotation.LineIntent = PdfLineIntent.LineDimension;

//Assigns the line ending style.
lineAnnotation.BeginLineStyle = PdfLineEndingStyle.Butt;
lineAnnotation.EndLineStyle = PdfLineEndingStyle.Diamond;
lineAnnotation.AnnotationFlags = PdfAnnotationFlags.Default;

//Assigns the line color.
lineAnnotation.InnerLineColor = new PdfColor(Color.Green);
lineAnnotation.BackColor = new PdfColor(Color.Green);

//Assigns the leader line.
lineAnnotation.LeaderLineExt = 0;
lineAnnotation.LeaderLine = 0;

//Assigns the Line caption type.
lineAnnotation.LineCaption = true;
lineAnnotation.CaptionType = PdfLineCaptionType.Inline;

//Adds this annotation to a new page.
page.Annotations.Add(lineAnnotation);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
