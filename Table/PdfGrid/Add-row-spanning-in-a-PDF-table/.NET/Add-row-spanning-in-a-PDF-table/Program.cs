﻿using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Create the page.
    PdfPage page = document.Pages.Add();

    //Create a PdfGrid.
    PdfGrid pdfGrid = new PdfGrid();

    //Create and customize the string formats.
    PdfStringFormat format = new PdfStringFormat();
    format.Alignment = PdfTextAlignment.Center;
    format.LineAlignment = PdfVerticalAlignment.Middle;

    //Add columns to PdfGrid.
    pdfGrid.Columns.Add(5);

    //Add rows to PdfGrid.
    for (int i = 0; i < pdfGrid.Columns.Count; i++)
    {
        PdfGridRow row = pdfGrid.Rows.Add();
        row.Height = 20;
    }

    //Add RowSpan.
    PdfGridCell gridCell = pdfGrid.Rows[1].Cells[3];
    gridCell.RowSpan = 3;
    gridCell.StringFormat = format;
    gridCell.Value = "Row Span";
    gridCell.Style.BackgroundBrush = PdfBrushes.Yellow;

    //Draw the PdfGrid.
    pdfGrid.Draw(page, new PointF(10, 10));

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
