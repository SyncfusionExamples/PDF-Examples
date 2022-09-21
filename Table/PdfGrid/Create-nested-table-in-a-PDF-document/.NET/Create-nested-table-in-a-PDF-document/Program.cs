// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using System.Reflection.Metadata;

//Create a new PDF document.
PdfDocument pdfDocument = new PdfDocument();

//Create the page.
PdfPage pdfPage = pdfDocument.Pages.Add();

//Create the parent grid.
PdfGrid parentPdfGrid = new PdfGrid();

//Add columns in the parent grid.
parentPdfGrid.Columns.Add(3);
parentPdfGrid.Columns[2].Width = 300;

//Add the rows in the parent grid.
PdfGridRow row1 = parentPdfGrid.Rows.Add();
row1.Cells[0].Value = "Employee ID";
row1.Cells[1].Value = "Employee Name";
row1.Cells[2].Value = "Contact Details";

//Add the rows in the parent grid.
PdfGridRow row2 = parentPdfGrid.Rows.Add();
row2.Cells[0].Value = "E01";
row2.Cells[1].Value = "Clay";

//Create the child table. 
PdfGrid childPdfGrid = new PdfGrid();

//Add columns to the child grid. 
childPdfGrid.Columns.Add(2);

//Add the rows to the child grid. 
PdfGridRow childRow1 = childPdfGrid.Rows.Add();
childRow1.Cells[0].Value = "Phone";
childRow1.Cells[1].Value = "31 12 34 56";

PdfGridRow childRow2 = childPdfGrid.Rows.Add();
childRow2.Cells[0].Value = "Email";
childRow2.Cells[1].Value = "simonsbistro@outlook.com";

PdfGridRow childRow3 = childPdfGrid.Rows.Add();
childRow3.Cells[0].Value = "Address";
childRow3.Cells[1].Value = "Vinbaeltet 34, Denmark";

//Set the value as another child grid in a cell. 
parentPdfGrid.Rows[1].Cells[2].Value = childPdfGrid;

//Set padding for child grid. 
parentPdfGrid.Rows[1].Cells[2].Style.CellPadding = new PdfPaddings(5, 5, 5, 5);

//Draw the parent PdfGrid
parentPdfGrid.Draw(pdfPage, PointF.Empty);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    pdfDocument.Save(outputFileStream);
}

//Close the document.
pdfDocument.Close(true);
