// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create the document.
PdfDocument document = new PdfDocument();

//Create a page.
PdfPage page = document.Pages.Add();

//Add the first layer and enable the visibility.
PdfPageLayer layer = page.Layers.Add("Layer1", true);

//Create graphics for layer. 
PdfGraphics graphics = layer.Graphics;

//Set translate transform for layer graphics. 
graphics.TranslateTransform(100, 60);

//Set the pen. 
PdfPen pen = new PdfPen(Syncfusion.Drawing.Color.Red, 50);

//Set the bounds. 
RectangleF bounds = new RectangleF(0, 0, 50, 50);

//Draw Arc.
graphics.DrawArc(pen, bounds, 360, 360);

//Add another layer on the page and disable the visibility.
PdfPageLayer layer2 = page.Layers.Add("Layer2", false);

//Create graphics for layer2.
graphics = layer2.Graphics;

//Set translate transform for layer graphics. 
graphics.TranslateTransform(100, 180);

//Draw ellipse.
graphics.DrawEllipse(pen, bounds);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
