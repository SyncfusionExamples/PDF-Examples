﻿using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page to the PDF document.
    PdfPage pdfPage = document.Pages.Add();

    //Create a header and draw the image.
    RectangleF bounds = new RectangleF(0, 0, document.Pages[0].GetClientSize().Width, 50);

    //Create the template for header. 
    PdfPageTemplateElement header = new PdfPageTemplateElement(bounds);

    //Get stream from the image file. 
    FileStream imageStream = new FileStream(Path.GetFullPath(@"Data/Logo.jpg"), FileMode.Open, FileAccess.Read);

    //Load the image file. 
    PdfImage image = new PdfBitmap(imageStream);

    //Draw the image in the header.
    header.Graphics.DrawImage(image, new PointF(0, 0), new SizeF(100, 50));

    //Add the header at the top.
    document.Template.Top = header;

    //Create a Page template that can be used as footer.
    PdfPageTemplateElement footer = new PdfPageTemplateElement(bounds);

    //Create the font. 
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 7);

    //Create the brush. 
    PdfBrush brush = new PdfSolidBrush(Color.Black);

    //Create page number field.
    PdfPageNumberField pageNumber = new PdfPageNumberField(font, brush);

    //Create page count field.
    PdfPageCountField count = new PdfPageCountField(font, brush);

    //Add the fields in composite fields.
    PdfCompositeField compositeField = new PdfCompositeField(font, brush, "Page {0} of {1}", pageNumber, count);
    compositeField.Bounds = footer.Bounds;

    //Draw the composite field in footer.
    compositeField.Draw(footer.Graphics, new PointF(470, 40));

    //Add the footer template at the bottom.
    document.Template.Bottom = footer;

    //Set the font. 
    font = new PdfStandardFont(PdfFontFamily.Helvetica, 25);

    //Draw string. 
    pdfPage.Graphics.DrawString("Hello World!!!", font, PdfBrushes.Red, new PointF(10, 10));

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}