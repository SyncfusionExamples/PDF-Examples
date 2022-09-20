// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;
using System.Data.Common;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a page
PdfPage page = document.Pages.Add();

//Acquire the page's graphics.
PdfGraphics graphics = page.Graphics;

//Create a PdfLightTable.
PdfLightTable pdfLightTable = new PdfLightTable();

//Set the DataSourceType as Direct.
pdfLightTable.DataSourceType = PdfLightTableDataSourceType.TableDirect;

//Create columns.
pdfLightTable.Columns.Add(new PdfColumn("Roll Number"));
pdfLightTable.Columns.Add(new PdfColumn("Name"));
pdfLightTable.Columns.Add(new PdfColumn("Class"));

//Add rows.
pdfLightTable.Rows.Add(new object[] { "111", "john", "III" });

//Specify the column name.
pdfLightTable.Columns[1].ColumnName = "Student Name";

//Create and customize the string formats.
PdfStringFormat format = new PdfStringFormat();
format.Alignment = PdfTextAlignment.Center;
format.LineAlignment = PdfVerticalAlignment.Bottom;

//Apply the string format.
pdfLightTable.Columns[0].StringFormat = format;

//Style to display the header.
pdfLightTable.Style.ShowHeader = true;

//Draw the PdfLightTable.
pdfLightTable.Draw(page, Syncfusion.Drawing.PointF.Empty);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
