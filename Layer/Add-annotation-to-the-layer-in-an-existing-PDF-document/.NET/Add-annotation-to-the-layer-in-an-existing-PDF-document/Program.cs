// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

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

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);

