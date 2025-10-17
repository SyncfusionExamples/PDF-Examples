﻿using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add page to the document.
    PdfPage page = document.Pages.Add();

    //Create a PdfLightTable.
    PdfLightTable lightTable = new PdfLightTable();

    //Set the DataSourceType as Direct.
    lightTable.DataSourceType = PdfLightTableDataSourceType.TableDirect;

    //Create columns.
    lightTable.Columns.Add(new PdfColumn("ID"));
    lightTable.Columns.Add(new PdfColumn("Name"));
    lightTable.Columns.Add(new PdfColumn("Salary"));

    //Add rows.
    lightTable.Rows.Add(new object[] { "E01", "Clay", "$10,000" });
    lightTable.Rows.Add(new object[] { "E02", "Thomas", "$10,500" });
    lightTable.Rows.Add(new object[] { "E03", "Simon", "$12,000" });

    //create and customize the string formats.
    PdfStringFormat stringFormat = new PdfStringFormat();
    stringFormat.Alignment = PdfTextAlignment.Center;
    stringFormat.LineAlignment = PdfVerticalAlignment.Middle;
    stringFormat.CharacterSpacing = 2f;

    //Enable ShowHeader.
    lightTable.Style.ShowHeader = true;

    //Apply string format to a column.
    lightTable.Columns[1].StringFormat = stringFormat;

    //Draw PdfLightTable on page.
    lightTable.Draw(page, new PointF(10, 10));

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}