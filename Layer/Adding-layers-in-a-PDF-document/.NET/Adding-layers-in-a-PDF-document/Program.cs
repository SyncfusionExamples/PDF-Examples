﻿using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page to the PDF document. 
    PdfPage page = document.Pages.Add();

    //Add the first layer.
    PdfPageLayer layer = page.Layers.Add("Layer1");

    //Create graphics for layer. 
    PdfGraphics graphics = layer.Graphics;

    //Set translate transform. 
    graphics.TranslateTransform(100, 60);

    //Draw arc.
    PdfPen pen = new PdfPen(Syncfusion.Drawing.Color.Red, 50);

    RectangleF bounds = new RectangleF(0, 0, 50, 50);

    //Draw arc in layer graphics. 
    graphics.DrawArc(pen, bounds, 360, 360);

    //Add another layer on the page.
    PdfPageLayer layer2 = page.Layers.Add("Layer2");

    //Create graphics for another layer. 
    graphics = layer2.Graphics;

    //Set translate transform. 
    graphics.TranslateTransform(100, 180);

    //Draw ellipse.
    graphics.DrawEllipse(pen, bounds);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}


