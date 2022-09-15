// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Drawing;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a page.
PdfPage page = document.Pages.Add();

//Create a PdfGrid.
PdfGrid grid = new PdfGrid();

//Add values to the list.
List<object> data = new List<object>();

object row1 = new { CustomerID = "ALFKI", CompanyName = "Alfreds Futterkiste", ContactName = "Maria Anders", Address = "Obere Str. 57", City = "Berlin", PostalCode = "12209", Country = "Germany" };
object row2 = new { CustomerID = "ANATR", CompanyName = "Ana Trujillo Emparedados yhelados", ContactName = "Ana Trujillo", Address = "Avda. de la Constitucion 2222", City = "Mexico D.F.", PostalCode = "05021", Country = "Mexico" };
object row3 = new { CustomerID = "ANTON", CompanyName = "Antonio Moreno Taqueria", ContactName = "Antonio Moreno", Address = "Mataderos 2312", City = "Mexico D.F.", PostalCode = "05023", Country = "Mexico" };

data.Add(row1);
data.Add(row2);
data.Add(row3);

//Add list to the IEnumerable
IEnumerable<object> dataTable = data;

//Assign data source.
grid.DataSource = dataTable;

//Create a new instance for string format.
PdfStringFormat format = new PdfStringFormat();

//Set a word wrap to string format. 
format.WordWrap = PdfWordWrapType.Word;

//Set the word wrapping in the PDF table cell.
foreach (PdfGridRow row in grid.Headers)
{
    foreach (PdfGridCell cell in row.Cells)
    {
        cell.Style.StringFormat = format;
    }
}

//Draw a grid to the resultant page of the first grid.
grid.Draw(page, new PointF(10, 20));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
