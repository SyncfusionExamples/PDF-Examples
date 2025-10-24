using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

// Create a new PDF document
using (PdfDocument document = new PdfDocument())
{
    // Add a page
    PdfPage page = document.Pages.Add();

    // Define the bounds for the annotation
    RectangleF bounds = new RectangleF(100, 100, 200, 50);

    // Create a FreeText annotation
    PdfFreeTextAnnotation freeText = new PdfFreeTextAnnotation(bounds);
    // Add content.
    freeText.Text = "Add Free Text Annotation with Intent";
    // Set the annotation intent to TypeWriter
    freeText.AnnotationIntent = PdfAnnotationIntent.FreeTextTypeWriter;

    // Customize appearance
    freeText.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
    freeText.TextMarkupColor = Color.Black;
    freeText.BorderColor = Color.Gray;
    freeText.Color = Color.LightYellow;

    // Add the annotation to the page
    page.Annotations.Add(freeText);

    // Save the document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}