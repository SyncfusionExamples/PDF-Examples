﻿using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;
using Syncfusion.Pdf;
using System.Reflection.Metadata;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page.
    PdfPage page = document.Pages.Add();

    //Acquire page's graphics.
    PdfGraphics graphics = page.Graphics;

    //Declare a PdfLightTable.
    PdfLightTable pdfLightTable = new PdfLightTable();

    //Set the Data source as direct.
    pdfLightTable.DataSourceType = PdfLightTableDataSourceType.TableDirect;

    //Create columns.
    pdfLightTable.Columns.Add(new PdfColumn("Roll Number"));
    pdfLightTable.Columns.Add(new PdfColumn("Name"));
    pdfLightTable.Columns.Add(new PdfColumn("Class"));

    //Add rows.
    pdfLightTable.Rows.Add(new object[] { "111", "Maxim", "III" });

    //Draw the PdfLightTable.
    pdfLightTable.Draw(page, Syncfusion.Drawing.PointF.Empty);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
