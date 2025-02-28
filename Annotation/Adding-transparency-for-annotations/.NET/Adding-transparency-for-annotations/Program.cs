using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

// Create a new PDF document.
PdfDocument document = new PdfDocument();
//Add a new page.
PdfPage page = document.Pages.Add();
//Create a new rectangle
RectangleF textAnnotationBounds = new RectangleF(10, 40, 100, 30);
//Create a new free text annotation.
PdfFreeTextAnnotation textAnnotation = new PdfFreeTextAnnotation(textAnnotationBounds);
//Set the text and font
textAnnotation.MarkupText = "Text Annotation";
textAnnotation.Font = new PdfStandardFont(PdfFontFamily.Courier, 10);

//Set transparency
textAnnotation.Opacity = 0.5F;

//Set the line caption type.
textAnnotation.AnnotationIntent = PdfAnnotationIntent.FreeTextCallout;
//Add this annotation to the PDF page.
page.Annotations.Add(textAnnotation);
//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document
document.Close(true);