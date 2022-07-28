// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a page.
PdfPage page = document.Pages.Add();

//Create a PdfGrid.
PdfGrid pdfGrid = new PdfGrid();

//Add values to list
List<object> data = new List<object>();

Object row1 = new { ID = "E01", Name = "Clay" };
Object row2 = new { ID = "E02", Name = "Thomas" };
Object row3 = new { ID = "E03", Name = "George" };
Object row4 = new { ID = "E04", Name = "Steffen" };
Object row5 = new { ID = "E05", Name = "Mathew" };

data.Add(row1);
data.Add(row2);
data.Add(row3);
data.Add(row4);
data.Add(row5);

//Add list to IEnumerable.
IEnumerable<object> dataTable = data;

//Assign data source.
pdfGrid.DataSource = dataTable;

PdfGridBuiltinStyleSettings tableStyleOption = new PdfGridBuiltinStyleSettings();
tableStyleOption.ApplyStyleForBandedRows = true;
tableStyleOption.ApplyStyleForHeaderRow = true;

//Apply built-in table style.
pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent4, tableStyleOption);

//Draw grid to the page of PDF document.
pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(10, 10));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);

