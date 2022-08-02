// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System.Data;

//Create a new PDF document.
PdfDocument pdfDocument = new PdfDocument();

//Add a page to PDF document. 
PdfPage pdfPage = pdfDocument.Pages.Add();

//Create a new PdfGrid.
PdfGrid pdfGrid = new PdfGrid();

//Create a DataTable.
DataTable dataTable = new DataTable();

//Add columns to the DataTable.
dataTable.Columns.Add("ID");
dataTable.Columns.Add("Name");

//Add rows to the DataTable.
dataTable.Rows.Add(new object[] { "E01", "John" });
dataTable.Rows.Add(new object[] { "E02", "Thomas" });
dataTable.Rows.Add(new object[] { "E03", "Peter" });

//Assign data source.
pdfGrid.DataSource = dataTable;

//Set the width.
pdfGrid.Columns[1].Width = 50;

//Create and customize the string formats.
PdfStringFormat format = new PdfStringFormat();
format.Alignment = PdfTextAlignment.Center;
format.LineAlignment = PdfVerticalAlignment.Bottom;

//Set the column text format.
pdfGrid.Columns[0].Format = format;

//Draw the PdfGrid.
PdfGridLayoutResult result = pdfGrid.Draw(pdfPage, PointF.Empty);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    pdfDocument.Save(outputFileStream);
}

//Close the document.
pdfDocument.Close(true);
