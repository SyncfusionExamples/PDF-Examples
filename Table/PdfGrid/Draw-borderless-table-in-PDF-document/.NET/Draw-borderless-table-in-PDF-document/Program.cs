using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using System.Reflection.Metadata;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Create the page.
    PdfPage pdfPage = document.Pages.Add();

    //Create a new PdfGrid.
    PdfGrid pdfGrid = new PdfGrid();

    //Add values to the list.
    List<object> data = new List<object>();

    Object row1 = new { RollNumber = "E01", Name = "Maxim", Class = "IV" };
    Object row2 = new { RollNumber = "E02", Name = "Clay", Class = "IV" };

    data.Add(row1);
    data.Add(row2);

    //Add list to the IEnumerable.
    IEnumerable<object> dataTable = data;

    //Assign data source.
    pdfGrid.DataSource = dataTable;

    //Declare and define the table cell style. 
    PdfGridCellStyle headerStyle = new PdfGridCellStyle();

    //Set the border color for the table.
    headerStyle.Borders.All = new PdfPen(Color.Transparent);

    //Set the text color for the header. 
    headerStyle.TextBrush = PdfBrushes.Red;

    //Apply the cell style for the header cells. 
    for (int i = 0; i < pdfGrid.Headers[0].Cells.Count; i++)
    {
        //Get the header cell.
        PdfGridCell headerCell = pdfGrid.Headers[0].Cells[i];

        //Apply the header style. 
        headerCell.Style = headerStyle;
    }

    //Declare and define the table cell style. 
    PdfGridCellStyle cellStyle = new PdfGridCellStyle();

    //Set the border color for the table.
    cellStyle.Borders.All = new PdfPen(Color.Transparent);

    //Apply the cell style for the row cells.
    for (int i = 0; i < pdfGrid.Rows.Count; i++)
    {
        //Get the row. 
        PdfGridRow row = pdfGrid.Rows[i];

        for (int j = 0; j < row.Cells.Count; j++)
        {
            //Get the cell. 
            PdfGridCell cell = row.Cells[j];

            //Apply the cell style. 
            cell.Style = cellStyle;
        }
    }

    //Draw a grid to the page of a PDF document.
    pdfGrid.Draw(pdfPage, new PointF(10, 10));

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
