using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf;
using System.Data;
using Syncfusion.Drawing;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page.
    PdfPage page = document.Pages.Add();
    //Create a PdfGrid.
    PdfGrid pdfGrid = new PdfGrid();
    //Create a DataTable.
    DataTable dataTable = new DataTable();
    //Add columns to the DataTable
    dataTable.Columns.Add("ID");
    dataTable.Columns.Add("Name");
    //Add rows to the DataTable.
    dataTable.Rows.Add(new object[] { "E01", "Clay" });
    dataTable.Rows.Add(new object[] { "E02", "Thomas" });
    //Assign data source.
    pdfGrid.DataSource = dataTable;

    //Create Cell Style
    PdfGridCellStyle headerStyle = new PdfGridCellStyle();
    headerStyle.TextBrush = PdfBrushes.Red;
    headerStyle.BackgroundBrush = new PdfSolidBrush(Syncfusion.Drawing.Color.LightBlue);
    //Apply style to the header row
    pdfGrid.Headers[0].ApplyStyle(headerStyle);

    //Create Cell Style
    PdfGridCellStyle rowStyle = new PdfGridCellStyle();
    rowStyle.TextBrush = PdfBrushes.Cyan;
    rowStyle.BackgroundBrush = new PdfSolidBrush(Syncfusion.Drawing.Color.YellowGreen);
    //Apply style to the first row
    pdfGrid.Rows[0].ApplyStyle(rowStyle);

    //Draw grid to the page of PDF document.
    pdfGrid.Draw(page, new PointF(10, 10));

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}