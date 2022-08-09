// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create the PDF document.
PdfDocument document = new PdfDocument();

//Add page to the document. 
PdfPage page = document.Pages.Add();

//Add the parent layer.
PdfLayer layer = document.Layers.Add("Layer1");

//Create graphics for layer.
PdfGraphics graphics = layer.CreateGraphics(page);

//Set translate transform for the graphics. 
graphics.TranslateTransform(100, 60);

//Draw an arc.
PdfPen pen = new PdfPen(Color.Red, 50);

//Set the bounds. 
RectangleF bounds = new RectangleF(0, 0, 50, 50);

//Draw an arc in layer graphics.  
graphics.DrawArc(pen, bounds, 360, 360);

//Add the child layer.
PdfLayer layer2 = layer.Layers.Add("Layer2");

//Create graphics for child layer. 
graphics = layer2.CreateGraphics(page);

//Set translate tranform for layer graphics. 
graphics.TranslateTransform(100, 180);

//Draw an ellipse.
graphics.DrawEllipse(pen, bounds);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
