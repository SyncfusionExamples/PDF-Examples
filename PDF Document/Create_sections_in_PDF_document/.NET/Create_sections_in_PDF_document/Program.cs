﻿using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a section to PDF document.
    PdfSection section = document.Sections.Add();

    //Set the page size for section.
    section.PageSettings.Size = PdfPageSize.A3;

    //Add pages to the section.
    PdfPage page = section.Pages.Add();

    //Create PDF graphics for the page.
    PdfGraphics graphics = page.Graphics;

    //Set the font.
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

    //Draw text to the page. 
    graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
