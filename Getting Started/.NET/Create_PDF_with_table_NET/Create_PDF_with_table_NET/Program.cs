
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf;
using System.Data;


//Create a new PDF document.
PdfDocument doc = new PdfDocument();
//Add a page.
PdfPage page = doc.Pages.Add();
//Create a PdfGrid.
PdfGrid pdfGrid = new PdfGrid();
//Create a DataTable.
DataTable dataTable = new DataTable();
//Add columns to the DataTable.
dataTable.Columns.Add("ProductID");
dataTable.Columns.Add("ProductName");
dataTable.Columns.Add("Quantity");
dataTable.Columns.Add("UnitPrice");
dataTable.Columns.Add("Discount");
dataTable.Columns.Add("Price");
//Add rows to the DataTable.
dataTable.Rows.Add(new object[] { "CA-1098", "Queso Cabrales", "12", "14", "1", "167" });
dataTable.Rows.Add(new object[] { "LJ-0192-M", "Singaporean Hokkien Fried Mee", "10", "20", "3", "197" });
dataTable.Rows.Add(new object[] { "SO-B909-M", "Mozzarella di Giovanni", "15", "65", "10", "956" });
//Assign data source.
pdfGrid.DataSource = dataTable;
//Draw grid to the page of PDF document.
pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(10, 10));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    doc.Save(outputFileStream);
}
//Close the document.
doc.Close(true);
