// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a new page.
PdfPage page = document.Pages.Add();

//Initialize the UriAnnotation to pass it in the grid cell.
RectangleF rectangle = new RectangleF(10, 40, 30, 30);
PdfUriAnnotation uriAnnotation = new PdfUriAnnotation(rectangle, "http://www.google.com");

//Set the annotation text. 
uriAnnotation.Text = "Uri Annotation";

//Create a new pdf grid.
PdfGrid grid = new PdfGrid();

//Add columns to the grid. 
grid.Columns.Add(3);

//Add rows. 
PdfGridRow row = grid.Rows.Add();
row.Cells[0].Value = "First Cell";

//Assign the UriAnnotation as a hyperlink in the grid cell. 
row.Cells[1].Value = uriAnnotation;
row.Cells[2].Value = "Third Cell";

//Create the grid cell style.
PdfGridCellStyle cellStyle = new PdfGridCellStyle();
cellStyle.TextBrush = PdfBrushes.Blue;

//Apply the cell style to the annotation cell. 
row.Cells[1].Style = cellStyle;

//Draw the grid.
grid.Draw(page, new PointF(0, 0));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
