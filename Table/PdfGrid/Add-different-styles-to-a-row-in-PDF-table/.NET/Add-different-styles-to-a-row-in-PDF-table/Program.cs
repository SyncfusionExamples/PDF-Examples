// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;

//Create a new PDF document.
PdfDocument pdfDocument = new PdfDocument();

//Add a new page. 
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

//Initialize PdfStringFormat and set the properties.
PdfStringFormat stringFormat = new PdfStringFormat();
stringFormat.Alignment = PdfTextAlignment.Center;
stringFormat.LineAlignment = PdfVerticalAlignment.Middle;
stringFormat.CharacterSpacing = 2f;

//Initialize PdfGridCellStyle. Set background color and string format
PdfGridCellStyle gridCellStyle = new PdfGridCellStyle();
gridCellStyle.BackgroundBrush = PdfBrushes.Yellow;
gridCellStyle.StringFormat = stringFormat;

//Initialize PdfGridRow and apply PdfGridCellStyle to the row.
PdfGridRow gridRow = pdfGrid.Rows[0];
gridRow.ApplyStyle(gridCellStyle);

//Initialize PdfGridCellStyle and set background image.
FileStream imageStream = new FileStream(Path.GetFullPath("../../../Autumn Leaves.jpg"), FileMode.Open);
gridCellStyle = new PdfGridCellStyle();
gridCellStyle.BackgroundImage = PdfImage.FromStream(imageStream);

//Initialize PdfGridRow and apply PdfGridCellStyle to the row.
gridRow = pdfGrid.Rows[1];
gridRow.ApplyStyle(gridCellStyle);

//Initialize PdfGridCellStyle. Set the border color and text color.
gridCellStyle = new PdfGridCellStyle();
gridCellStyle.Borders.All = PdfPens.Red;
gridCellStyle.TextBrush = PdfBrushes.DarkBlue;

//Initialize PdfGridRow and apply PdfGridCellStyle to the row.
gridRow = pdfGrid.Rows[2];
gridRow.ApplyStyle(gridCellStyle);

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
