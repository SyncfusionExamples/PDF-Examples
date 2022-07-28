// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;

//Create a new PDF document.
PdfDocument pdfDocument = new PdfDocument();

//Add a PDF page.
PdfPage pdfPage = pdfDocument.Pages.Add();

//Create a new PdfGrid instance.
PdfGrid pdfGrid = new PdfGrid();

//Add values to list.
List<object> data = new List<object>();
Object grid1row1 = new { ID = "E01", Name = "Clay", Salary = "$10,000" };
Object grid1row2 = new { ID = "E02", Name = "Thomas", Salary = "$10,500" };
Object grid1row3 = new { ID = "E03", Name = "Simon", Salary = "$12,000" };

data.Add(grid1row1);
data.Add(grid1row2);
data.Add(grid1row3);

//Add list to IEnumerable.
IEnumerable<object> dataTable = data;

//Assign data source to PdfGrid.
pdfGrid.DataSource = dataTable;

//Assign row height and column width.
pdfGrid.Rows[1].Height = 50;
pdfGrid.Columns[1].Width = 100;

//Initialize PdfGridCellStyle and set background color.
PdfGridCellStyle gridCellStyle = new PdfGridCellStyle();
gridCellStyle.BackgroundBrush = PdfBrushes.Yellow;

//Assign background color to a PdfGridCell.
PdfGridCell gridCell = pdfGrid.Rows[0].Cells[0];
gridCell.Style = gridCellStyle;

//Initialize PdfGridCellStyle and set background image.
FileStream imageStream = new FileStream(Path.GetFullPath("../../../Autumn Leaves.jpg"), FileMode.Open);
gridCellStyle = new PdfGridCellStyle();
gridCellStyle.BackgroundImage = PdfImage.FromStream(imageStream);

//Assign background image to a PdfGridCell.
gridCell = pdfGrid.Rows[1].Cells[1];
gridCell.Style = gridCellStyle;
gridCell.ImagePosition = PdfGridImagePosition.Fit;

//Initialize PdfGridCellStyle and set the border color.
gridCellStyle = new PdfGridCellStyle();
gridCellStyle.Borders.All = PdfPens.Red;

//Assign the border color to a PdfGridCell.
gridCell = pdfGrid.Rows[2].Cells[2];
gridCell.Style = gridCellStyle;

//Initialize PdfGridCellStyle and set text color.
gridCellStyle = new PdfGridCellStyle();
gridCellStyle.TextBrush = PdfBrushes.DarkBlue;

//Assign text color to a PdfGridCell.
gridCell = pdfGrid.Rows[0].Cells[2];
gridCell.Style = gridCellStyle;

//Set the column span.
pdfGrid.Rows[2].Cells[0].ColumnSpan = 2;

//Initialize PdfStringFormat and set the properties.
PdfStringFormat stringFormat = new PdfStringFormat();
stringFormat.Alignment = PdfTextAlignment.Center;
stringFormat.LineAlignment = PdfVerticalAlignment.Middle;

//Set the PdfStringFormat to PdfGridCell.
gridCell = pdfGrid.Rows[2].Cells[0];
gridCell.StringFormat = stringFormat;

//Draw the table in the PDF page.
pdfGrid.Draw(pdfPage, new PointF(10, 10));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    pdfDocument.Save(outputFileStream);
}

//Close the document.
pdfDocument.Close(true);