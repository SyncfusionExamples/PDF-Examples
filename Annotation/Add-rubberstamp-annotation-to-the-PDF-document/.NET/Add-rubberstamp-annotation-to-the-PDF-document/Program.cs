// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Creates a new PDF document.
PdfDocument document = new PdfDocument();

//Creates a new page.
PdfPage page = document.Pages.Add();

//Creates a new pdf rubber stamp annotation.
RectangleF rectangle = new RectangleF(40, 60, 80, 20);

//Create rubber stamp annotation with some properties. 
PdfRubberStampAnnotation rubberStampAnnotation = new PdfRubberStampAnnotation(rectangle, " Text Rubber Stamp Annotation");
rubberStampAnnotation.Icon = PdfRubberStampAnnotationIcon.Draft;
rubberStampAnnotation.Text = "Text Properties Rubber Stamp Annotation";

//Adds annotation to the page.
page.Annotations.Add(rubberStampAnnotation);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
