// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a page.
PdfPage page = document.Pages.Add();

//Create a new PdfGrid instance.
PdfGrid pdfGrid = new PdfGrid();

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
pdfGrid.DataSource = dataTable;

//Draw grid on the page of PDF document and store the grid position in PdfGridLayoutResult.
PdfGridLayoutResult pdfGridLayoutResult = pdfGrid.Draw(page, new PointF(10, 10));

//Initialize PdfGrid and list.
pdfGrid = new PdfGrid();
data = new List<object>();

//Add values to the list.
Object grid2row1 = new { Name = "Andrew", Age = "21", Sex = "Male" };
Object grid2row2 = new { Name = "Steven", Age = "22", Sex = "Female" };
Object grid2row3 = new { Name = "Michael", Age = "24", Sex = "Male" };
data.Add(grid2row1);
data.Add(grid2row2);
data.Add(grid2row3);

//Add list to IEnumerable.
dataTable = data;

//Assign data source.
pdfGrid.DataSource = dataTable;

//Draw the grid on page using previous result.
pdfGrid.Draw(page, new PointF(10, pdfGridLayoutResult.Bounds.Bottom + 20));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
