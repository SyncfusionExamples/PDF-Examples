// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;

//Create a new PDF document.
PdfDocument pdfDocument = new PdfDocument();

//Create the page.
PdfPage pdfPage = pdfDocument.Pages.Add();

//Create the parent grid.
PdfGrid parentPdfGrid = new PdfGrid();

//Add the rows.
PdfGridRow row1 = parentPdfGrid.Rows.Add();
PdfGridRow row2 = parentPdfGrid.Rows.Add();
row2.Height = 58;

//Add the columns.
parentPdfGrid.Columns.Add(3);

//Set the value to the specific cell.
parentPdfGrid.Rows[0].Cells[0].Value = "Nested Table";
parentPdfGrid.Rows[0].Cells[1].RowSpan = 2;
parentPdfGrid.Rows[0].Cells[1].ColumnSpan = 2;

//Create the child table.
PdfGrid childPdfGrid = new PdfGrid();

//Set the column and rows for child grid.
childPdfGrid.Columns.Add(5);

for (int i = 0; i < 5; i++)
{
    PdfGridRow row = childPdfGrid.Rows.Add();
    for (int j = 0; j < 5; j++)
    {
        row.Cells[j].Value = String.Format("Cell [{0} {1}]", j, i);
    }
}

//Set the value as another PdfGrid in a cell.
parentPdfGrid.Rows[0].Cells[1].Value = childPdfGrid;

//Specify the style for the PdfGridCell.
PdfGridCellStyle pdfGridCellStyle = new PdfGridCellStyle();
pdfGridCellStyle.TextPen = PdfPens.Red;
pdfGridCellStyle.Borders.All = PdfPens.Red;

//Load image as stream.
FileStream imageStream = new FileStream(Path.GetFullPath("../../../Image.jpg"), FileMode.Open, FileAccess.Read);
pdfGridCellStyle.BackgroundImage = new PdfBitmap(imageStream);
PdfGridCell pdfGridCell = parentPdfGrid.Rows[1].Cells[0];

//Apply style.
pdfGridCell.Style = pdfGridCellStyle;

//Set image position for the background image in the style.
pdfGridCell.ImagePosition = PdfGridImagePosition.Fit;

//Draw the PdfGrid.
parentPdfGrid.Draw(pdfPage, Syncfusion.Drawing.PointF.Empty);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    pdfDocument.Save(outputFileStream);
}

//Close the document.
pdfDocument.Close(true);