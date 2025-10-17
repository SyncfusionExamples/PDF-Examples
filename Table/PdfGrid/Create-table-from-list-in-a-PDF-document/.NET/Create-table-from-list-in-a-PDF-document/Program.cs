﻿using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page.
    PdfPage page = document.Pages.Add();

    //Create a PdfGrid.
    PdfGrid pdfGrid = new PdfGrid();

    //Add values to list
    List<object> data = new List<object>();
    Object row1 = new { ID = "1", Name = "Clay" };
    Object row2 = new { ID = "2", Name = "Gray" };
    Object row3 = new { ID = "3", Name = "Ash" };

    //Add rows to the list.
    data.Add(row1);
    data.Add(row2);
    data.Add(row3);

    //Add list to IEnumerable.
    IEnumerable<object> tableData = data;

    //Assign data source.
    pdfGrid.DataSource = tableData;

    //Draw grid to the page of PDF document.
    pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(10, 10));

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}