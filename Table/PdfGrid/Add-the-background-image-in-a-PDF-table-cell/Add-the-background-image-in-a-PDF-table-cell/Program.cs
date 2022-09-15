// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using System.Reflection.Metadata;

//Create a new PDF document.
PdfDocument pdfDocument = new PdfDocument();

//Add a page to the PDF document.
PdfPage pdfPage = pdfDocument.Pages.Add();

//Create a new PdfGrid.
PdfGrid pdfGrid = new PdfGrid();

//Add three columns.
pdfGrid.Columns.Add(3);

//Add the header.
pdfGrid.Headers.Add(1);
PdfGridRow pdfGridHeader = pdfGrid.Headers[0];
pdfGridHeader.Cells[0].Value = "Employee ID";
pdfGridHeader.Cells[1].Value = "Employee Name";
pdfGridHeader.Cells[2].Value = "Salary";

//Add rows.
PdfGridRow pdfGridRow = pdfGrid.Rows.Add();
pdfGridRow.Cells[0].Value = "E01";
pdfGridRow.Cells[1].Value = "Clay";
pdfGridRow.Cells[2].Value = "$10,000";

//Specify the style for the PdfGridCell.
PdfGridCellStyle pdfGridCellStyle = new PdfGridCellStyle();

//Load the image from the disk.
FileStream imageStream = new FileStream(Path.GetFullPath("../../../sample.png"), FileMode.Open, FileAccess.Read);
PdfBitmap image = new PdfBitmap(imageStream);

//Set the background image. 
pdfGridCellStyle.BackgroundImage = image;
pdfGridCellStyle.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 10, PdfFontStyle.Bold);

//Apply the cell style.
PdfGridCell pdfGridCell = pdfGrid.Rows[0].Cells[0];
pdfGridCell.Style = pdfGridCellStyle;

//Set the row height. 
pdfGrid.Rows[0].Height = 50;

//Set the image position for the background image in style.
pdfGridCell.ImagePosition = PdfGridImagePosition.Stretch;

//Draw the PdfGrid.
pdfGrid.Draw(pdfPage, PointF.Empty);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    pdfDocument.Save(outputFileStream);
}

//Close the document.
pdfDocument.Close(true);

