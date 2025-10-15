using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Gets the first page from the document.
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

    //Add the layer.
    PdfLayer Layer = loadedDocument.Layers.Add("Layer");

    //Create graphics for layer.
    PdfGraphics graphics = Layer.CreateGraphics(loadedPage);

    //Draw ellipse.
    graphics.DrawEllipse(PdfPens.Red, new RectangleF(50, 80, 40, 40));

    //Create square annotation.
    PdfSquareAnnotation annotation = new PdfSquareAnnotation(new RectangleF(200, 260, 50, 50), "Square annotation");

    //Set the annotation color. 
    annotation.Color = new PdfColor(Syncfusion.Drawing.Color.Red);

    //Set layer to annotation.
    annotation.Layer = Layer;

    //Add annotation to the created page.
    loadedPage.Annotations.Add(annotation);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

