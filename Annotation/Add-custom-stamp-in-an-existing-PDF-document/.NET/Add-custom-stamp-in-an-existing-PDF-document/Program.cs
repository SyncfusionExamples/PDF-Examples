﻿using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Add_custom_stamp_in_an_existing_PDF_document;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the page from loaded PDF document
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

    //Create a new pdf rubber stamp annotation.
    RectangleF rectangleF = new RectangleF(350, 20, 200, 80);
    PdfRubberStampAnnotation rubberStampAnnotation = new PdfRubberStampAnnotation(rectangleF);

    //Custom stamp the rubber stamp annotation.
    PdfSolidBrush brush = new PdfSolidBrush(new PdfColor(Color.FromArgb(255, 173, 216, 230)));

    //Create object for RoundRect class to call RoundRect method.  
    RoundRect sub = new RoundRect();

    //Get the path for rounded rectangle. 
    PdfPath path = sub.RoundedRect(new RectangleF(0, 0, 200, 80), 20);

    //Draw path in the rubber stamp annotation. 
    rubberStampAnnotation.Appearance.Normal.Graphics.DrawPath(brush, path);

    //Create the font. 
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Bold);

    //Add text in rubber stamp annotation.
    rubberStampAnnotation.Appearance.Normal.Graphics.DrawString("DD/2018/1234567890", font, PdfBrushes.Black, new PointF(10, 20));
    rubberStampAnnotation.Appearance.Normal.Graphics.DrawString(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), font, PdfBrushes.Black, new PointF(10, 40));

    //Set the content of annotation.
    rubberStampAnnotation.Text = "Text Properties Rubber Stamp Annotation";

    //Add annotation to the page.
    loadedPage.Annotations.Add(rubberStampAnnotation);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
