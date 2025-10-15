using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add page.
    PdfPage page = document.Pages.Add();

    //Add the layer.
    PdfLayer layer = document.Layers.Add("Layer");

    //Create graphics for layer.
    PdfGraphics graphics = layer.CreateGraphics(page);

    //Draw ellipse.
    graphics.DrawEllipse(PdfPens.Red, new RectangleF(50, 50, 40, 40));

    //Create square annotation.
    PdfSquareAnnotation annotation = new PdfSquareAnnotation(new RectangleF(200, 260, 50, 50), "Square annotation");

    //Set the annotation color.
    annotation.Color = new PdfColor(Syncfusion.Drawing.Color.Red);

    //Set layer to annotation.
    annotation.Layer = layer;

    //Add annotation to the created page.
    page.Annotations.Add(annotation);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}