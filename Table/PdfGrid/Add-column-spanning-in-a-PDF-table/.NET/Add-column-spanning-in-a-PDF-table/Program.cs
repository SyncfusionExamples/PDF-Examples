// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Create the page.
PdfPage page = document.Pages.Add();

//Create a PdfGrid.
PdfGrid pdfGrid = new PdfGrid();

//Create and customize the string formats.
PdfStringFormat format = new PdfStringFormat();
format.Alignment = PdfTextAlignment.Center;
format.LineAlignment = PdfVerticalAlignment.Middle;

//Add columns to PdfGrid.
pdfGrid.Columns.Add(5);

//Add rows to PdfGrid.
for (int i = 0; i < pdfGrid.Columns.Count; i++)
{
    PdfGridRow row = pdfGrid.Rows.Add();
    row.Height = 20;
}

//Add ColumnSpan.
PdfGridCell gridCell = pdfGrid.Rows[1].Cells[0];
gridCell.ColumnSpan = 2;
gridCell.StringFormat = format;
gridCell.Value = "Column Span";
gridCell.Style.BackgroundBrush = PdfBrushes.Yellow;

//Draw the PdfGrid.
pdfGrid.Draw(page, new PointF(10, 10));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
