// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using System.Reflection.Metadata;

//Create a new PDF document.
PdfDocument pdfDocument = new PdfDocument();

//Create the page.
PdfPage pdfPage = pdfDocument.Pages.Add();

//Create a new PdfGrid.
PdfGrid pdfGrid = new PdfGrid();

//Add a row.
PdfGridRow row1 = pdfGrid.Rows.Add();

//Add columns.
pdfGrid.Columns.Add(3);

//Set the value to the specific cell.
row1.Cells[0].Value = "Employee Details";
row1.Cells[0].ColumnSpan = 3;

//Add a row.
PdfGridRow row2 = pdfGrid.Rows.Add();
row2.Cells[0].Value = "Employee ID";
row2.Cells[1].Value = "Employee Name";
row2.Cells[2].Value = "Employee Address";

//Add a row.
PdfGridRow row3 = pdfGrid.Rows.Add();
row3.Cells[0].Value = "E01";
row3.Cells[1].Value = "Simons Bistro";
row3.Height = 50;

//Call the event handler to add the string to a particular cell.
pdfGrid.BeginCellLayout += PdfGrid_BeginCellLayout;

//Create and customize the string formats.
PdfStringFormat format = new PdfStringFormat();
format.Alignment = PdfTextAlignment.Center;
pdfGrid.Rows[0].Cells[0].StringFormat = format;

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



//Event handler to add differnt font styles. 
static void PdfGrid_BeginCellLayout(object sender, PdfGridBeginCellLayoutEventArgs args)
{
    //Draw multiple fonts for a particular table cell.
    if (args.RowIndex == 2 && args.CellIndex == 2)
    {
        //Draw a string. 
        PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 10, PdfFontStyle.Bold);
        args.Graphics.DrawString("Phone: 31 12 34 56", font, PdfBrushes.Black, args.Bounds.X, args.Bounds.Y);
        font = new PdfStandardFont(PdfFontFamily.TimesRoman, 10, PdfFontStyle.Italic);
        args.Graphics.DrawString("Email: simonsbistro@outlook.com ", font, PdfBrushes.Black, args.Bounds.X, args.Bounds.Y + 12);
        font = new PdfStandardFont(PdfFontFamily.Courier, 10, PdfFontStyle.Italic);
        args.Graphics.DrawString("Address:Vinbaeltet 34,US", font, PdfBrushes.Black, args.Bounds.X, args.Bounds.Y + (2 * 12));
    }
}
