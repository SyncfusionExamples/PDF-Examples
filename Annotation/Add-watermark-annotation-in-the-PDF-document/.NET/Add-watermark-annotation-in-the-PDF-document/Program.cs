﻿using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the page.
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

    //Creates PDF watermark annotation.
    PdfWatermarkAnnotation watermark = new PdfWatermarkAnnotation(new RectangleF(50, 50, 400, 100));

    //Sets properties to the annotation.
    watermark.Opacity = 0.5f;

    //Create the appearance of watermark.
    watermark.Appearance.Normal.Graphics.DrawString("Watermark Text", new PdfStandardFont(PdfFontFamily.Helvetica, 20), PdfBrushes.Red, new RectangleF(0, 0, 200, 50), new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle));

    //Adds the annotation to page.
    loadedPage.Annotations.Add(watermark);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}