// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a page.
PdfPage page = document.Pages.Add();

//Acquire page's graphics.
PdfGraphics graphics = page.Graphics;

//Declare a PdfLightTable.
PdfLightTable pdfLightTable = new PdfLightTable();

//Set the Data source as direct.
pdfLightTable.DataSourceType = PdfLightTableDataSourceType.TableDirect;

//Create columns.
pdfLightTable.Columns.Add(new PdfColumn("Roll Number"));
pdfLightTable.Columns.Add(new PdfColumn("Name"));
pdfLightTable.Columns.Add(new PdfColumn("Class"));

//Add rows.
pdfLightTable.Rows.Add(new object[] { "111", "Maxim", "III" });

pdfLightTable.Style.ShowHeader = true;

//Draw the PdfLightTable.
pdfLightTable.Draw(page, PointF.Empty);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream
    document.Save(outputFileStream);
}

//Close the document
document.Close(true);