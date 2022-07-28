// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a page.
PdfPage page = document.Pages.Add();

//Create a PdfGrid.
PdfGrid pdfGrid = new PdfGrid();

//Add values to list.
List<object> data = new List<object>();
Object row1 = new { ID = "E01", Name = "Clay" };
Object row2 = new { ID = "E02", Name = "Thomas" };

//Add rows to list.
data.Add(row1);
data.Add(row2);

//Add list to IEnumerable.
IEnumerable<object> dataTable = data;

//Assign data source.
pdfGrid.DataSource = dataTable;

//Declare and define the grid style
PdfGridStyle gridStyle = new PdfGridStyle();

//Set cell padding, which specifies the space between border and content of the cell.
gridStyle.CellPadding = new PdfPaddings(2, 2, 2, 2);

//Set cell spacing, which specifies the space between the adjacent cells.
gridStyle.CellSpacing = 2;

//Enable to adjust PDF table row width based on the text length.
gridStyle.AllowHorizontalOverflow = true;

//Apply style.
pdfGrid.Style = gridStyle;

//Draw grid to the page of PDF document.
pdfGrid.Draw(page, new PointF(10, 10));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
