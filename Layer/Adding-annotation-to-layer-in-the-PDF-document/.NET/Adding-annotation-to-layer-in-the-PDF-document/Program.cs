// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Create new PDF document.
PdfDocument document = new PdfDocument();

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

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);