// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add new section to the document.
PdfSection section = document.Sections.Add();

//Add a page to the section.
PdfPage page = section.Pages.Add();

//Initialize PdfGrid.
PdfGrid grid = new PdfGrid();

//Add values to list.
List<object> data = new List<object>();
Object grid1row1 = new { Employee_ID = "E01", Employee_Name = "Clay", Employee_Role = "Sales Representative", Employee_DateOfBirth = "12/8/1948" };
Object grid1row2 = new { Employee_ID = "E02", Employee_Name = "Thomas", Employee_Role = "Sales Representative", Employee_DateOfBirth = "7/2/1963" };
Object grid1row3 = new { Employee_ID = "E03", Employee_Name = "Ash", Employee_Role = "Sales Manager", Employee_DateOfBirth = "3/4/1955" };
Object grid1row4 = new { Employee_ID = "E04", Employee_Name = "Andrew", Employee_Role = "Vice President, Sales", Employee_DateOfBirth = "2/19/1952" };

data.Add(grid1row1);
data.Add(grid1row2);
data.Add(grid1row3);
data.Add(grid1row4);

//Add list to IEnumerable.
IEnumerable<object> dataTable = data;

//Assign data source to grid.
grid.DataSource = dataTable;

//Apply the table style.
grid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable5DarkAccent5);

//Allow the horizontal overflow for PdfGrid.
grid.Style.AllowHorizontalOverflow = true;

//Draw the PdfGrid on page.
grid.Draw(page, PointF.Empty);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);