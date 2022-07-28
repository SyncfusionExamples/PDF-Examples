// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add page to the PdfDocument.
PdfPage page = document.Pages.Add();

//Create a new PdfGrid.
PdfGrid grid = new PdfGrid();

//Add values to list.
List<object> data = new List<object>();
Object grid1row1 = new { ID = "E01", Name = "Clay", Salary = "$10,000" };
Object grid1row2 = new { ID = "E02", Name = "Thomas", Salary = "$10,500" };
Object grid1row3 = new { ID = "E03", Name = "Simon", Salary = "$12,000" };
data.Add(grid1row1);
data.Add(grid1row2);
data.Add(grid1row3);

//Add list to IEnumerable.
IEnumerable<object> dataTable = data;

//Assign data source.
grid.DataSource = dataTable;

//create and customize the string formats.
PdfStringFormat stringFormat = new PdfStringFormat();
stringFormat.Alignment = PdfTextAlignment.Center;
stringFormat.LineAlignment = PdfVerticalAlignment.Middle;
stringFormat.CharacterSpacing = 2f;

//Assign string format to a row.
for (int i = 0; i < grid.Columns.Count; i++)
{
    grid.Rows[2].Cells[i].StringFormat = stringFormat;
}

//Draw the PdfGrid on page.
grid.Draw(page, new PointF(10, 10));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
