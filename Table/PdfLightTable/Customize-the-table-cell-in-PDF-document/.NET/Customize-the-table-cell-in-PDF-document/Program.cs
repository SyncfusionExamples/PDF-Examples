// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;
using System.Data.Common;
using System.Reflection.Metadata;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a page.
PdfPage page = document.Pages.Add();

//Create a PdfLightTable.
PdfLightTable pdfLightTable = new PdfLightTable();

//Set the DataSourceType as Direct.
pdfLightTable.DataSourceType = PdfLightTableDataSourceType.TableDirect;

//Create columns.
pdfLightTable.Columns.Add(new PdfColumn("Roll Number"));
pdfLightTable.Columns.Add(new PdfColumn("Name"));
pdfLightTable.Columns.Add(new PdfColumn("Class"));

//Add Rows.
pdfLightTable.Rows.Add(new object[] { "111", "Maxim", "III" });
pdfLightTable.Rows.Add(new object[] { "112", "Minim", "III" });

//Create the font for setting the style.
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 14);

//Declare and define the alternate style.
PdfCellStyle altStyle = new PdfCellStyle(font, PdfBrushes.White, PdfPens.Green);
altStyle.BackgroundBrush = PdfBrushes.DarkGray;

//Declare and define the header style.
PdfCellStyle headerStyle = new PdfCellStyle(font, PdfBrushes.White, PdfPens.Brown);
headerStyle.BackgroundBrush = PdfBrushes.Red;

//Set the alternate and header style to table. 
pdfLightTable.Style.AlternateStyle = altStyle;
pdfLightTable.Style.HeaderStyle = headerStyle;

//Show header in the table.
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