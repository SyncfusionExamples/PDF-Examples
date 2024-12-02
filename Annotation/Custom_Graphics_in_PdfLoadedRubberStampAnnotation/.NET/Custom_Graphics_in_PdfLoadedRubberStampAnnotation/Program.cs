using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

// Load the existing PDF document
FileStream fileStream = new FileStream(@"Data/Input.pdf", FileMode.Open, FileAccess.Read);
PdfLoadedDocument ldoc = new PdfLoadedDocument(fileStream);

// Load the custom image for the rubber stamp
FileStream paraphImage = new FileStream(@"Data/image.jpg", FileMode.Open, FileAccess.Read);
PdfBitmap paraphBitmap = new PdfBitmap(paraphImage);

// Loop through each page in the document
for (int i = 0; i < ldoc.Pages.Count; i++)
{
    PdfLoadedPage lpage = ldoc.Pages[i] as PdfLoadedPage;
    PdfLoadedAnnotationCollection annotations = ldoc.Pages[i].Annotations;

    // Iterate through annotations in the page
    foreach (PdfLoadedAnnotation annotation in annotations)
    {
        if (annotation is PdfLoadedRubberStampAnnotation rubberStamp)
        {
            // Get the annotation bounds
            RectangleF rectangleF = rubberStamp.Bounds;
            // Make the existing annotation invisible and remove it
            rubberStamp.AnnotationFlags = PdfAnnotationFlags.Invisible;
            annotations.Remove(rubberStamp);
            // Create a new rubber stamp annotation at the same location
            PdfRubberStampAnnotation rubberStampAnnotation = new PdfRubberStampAnnotation(rectangleF, "Text Rubber Stamp Annotation");
            rubberStampAnnotation.Icon = PdfRubberStampAnnotationIcon.Draft;
            rubberStampAnnotation.Text = "Text Properties Rubber Stamp Annotation";
            // Add custom graphics (image) to the annotation
            rubberStampAnnotation.Appearance.Normal.Graphics.DrawImage(paraphBitmap, 0, 0, rubberStampAnnotation.Bounds.Width, rubberStampAnnotation.Bounds.Height);
            // Add the new annotation to the page
            lpage.Annotations.Add(rubberStampAnnotation);
            break;
        }
    }
}
//Save the PDF document
using (FileStream output = new FileStream(@"Output/RubberStampAnnotation.pdf", FileMode.Create, FileAccess.Write))
{
    ldoc.Save(output);
}

// Close the document
ldoc.Close(true);
