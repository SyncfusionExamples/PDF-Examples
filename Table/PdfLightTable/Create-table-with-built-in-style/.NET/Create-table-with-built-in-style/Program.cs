﻿using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Tables;
using System.Data;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page.
    PdfPage page = document.Pages.Add();

    //Create a PdfLightTable.
    PdfLightTable pdfLightTable = new PdfLightTable();

    //Create a DataTable.
    DataTable dataTable = new DataTable();

    //Add columns to the DataTable.
    dataTable.Columns.Add("ID");
    dataTable.Columns.Add("Name");

    //Add rows to the DataTable.
    dataTable.Rows.Add(new object[] { "E01", "Clay" });
    dataTable.Rows.Add(new object[] { "E02", "Thomas" });
    dataTable.Rows.Add(new object[] { "E03", "George" });
    dataTable.Rows.Add(new object[] { "E04", "Stefan" });
    dataTable.Rows.Add(new object[] { "E05", "Mathew" });

    //Assign data source.
    pdfLightTable.DataSource = dataTable;

    //Apply built-in table style.
    pdfLightTable.ApplyBuiltinStyle(PdfLightTableBuiltinStyle.GridTable4Accent2);

    //Set to view the table header. 
    pdfLightTable.Style.ShowHeader = true;

    //Draw grid to the page of PDF document.
    pdfLightTable.Draw(page, new PointF(10, 10));

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
