// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add page to the document.
PdfPage page = document.Pages.Add();

//Create a PdfLightTable.
PdfLightTable lightTable = new PdfLightTable();

//Set the DataSourceType as Direct.
lightTable.DataSourceType = PdfLightTableDataSourceType.TableDirect;

//Create columns.
lightTable.Columns.Add(new PdfColumn("ID"));
lightTable.Columns.Add(new PdfColumn("Name"));
lightTable.Columns.Add(new PdfColumn("Salary"));

//Add rows.
lightTable.Rows.Add(new object[] { "E01", "Clay", "$10,000" });
lightTable.Rows.Add(new object[] { "E02", "Thomas", "$10,500" });
lightTable.Rows.Add(new object[] { "E03", "Simon", "$12,000" });

//Enable ShowHeader.
lightTable.Style.ShowHeader = true;

//Create and customize the string formats.
PdfStringFormat stringFormat = new PdfStringFormat();
stringFormat.Alignment = PdfTextAlignment.Center;
stringFormat.LineAlignment = PdfVerticalAlignment.Middle;
stringFormat.CharacterSpacing = 2f;

//Apply string formatting for whole table.
for (int i = 0; i < lightTable.Columns.Count; i++)
{
    lightTable.Columns[i].StringFormat = stringFormat;
}

//Draw the PdfLightTable on page.
lightTable.Draw(page, new PointF(10, 10));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);