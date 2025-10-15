﻿using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page to the document.
    PdfPage page = document.Pages.Add();

    //Create PDF graphics for the page.
    PdfGraphics graphics = page.Graphics;

    //Set the font.
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

    //Draw the text.
    graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));

    //Hide viewer application's menu bar.
    document.ViewerPreferences.HideMenubar = true;

    //Hide viewer application's toolbar.
    document.ViewerPreferences.HideToolbar = true;

    //Shows user interface elements in the document's window (such as scroll bars and navigation controls).
    document.ViewerPreferences.HideWindowUI = false;

    //Show the attachments panel.
    document.ViewerPreferences.PageMode = PdfPageMode.UseAttachments;


    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
