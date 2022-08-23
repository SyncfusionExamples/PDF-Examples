// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Load the page. 
PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

//Add the first layer.
PdfPageLayer layer = loadedPage.Layers.Add("Layer1");

//Create graphics for the layer. 
PdfGraphics graphics = layer.Graphics;

//Set translate transform for the graphics. 
graphics.TranslateTransform(100, 60);

//Draw arc.
PdfPen pen = new PdfPen(Syncfusion.Drawing.Color.Gray, 50);

RectangleF bounds = new RectangleF(0, 0, 50, 50);

//Draw arc in layer graphics. 
graphics.DrawArc(pen, bounds, 360, 360);

//Add another layer on the page.
PdfPageLayer layer2 = loadedPage.Layers.Add("Layer2");

//Create graphics for layer. 
graphics = layer2.Graphics;

//Set translate transform for layer graphics. 
graphics.TranslateTransform(100, 180);

//Draw ellipse.
graphics.DrawEllipse(pen, bounds);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);

