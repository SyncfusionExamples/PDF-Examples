using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf;

//Create a new PDF document.
PdfDocument document = new PdfDocument();
//Set page margins
document.PageSettings.Margins.Top = 50;
document.PageSettings.Margins.Bottom = 50;
//Add a new PDF page.
PdfPage page = document.Pages.Add();
//Create a PdfGrid.
PdfGrid pdfGrid = new PdfGrid();
//Add values to the list.
List<object> data = new List<object>();
for (int i = 0; i < 100; i++)
{
    Object row1 = new { ID = "1", Name = "Clay", Price = "$10" };
    Object row2 = new { ID = "2", Name = "Gray", Price = "$20" };
    Object row3 = new { ID = "3", Name = "Ash", Price = "$30" };
    data.Add(row1);
    data.Add(row2);
    data.Add(row3);
}
//Add list to IEnumerable.
IEnumerable<object> tableData = data;
//Assign data source.
pdfGrid.DataSource = tableData;
PdfGridLayoutFormat format = new PdfGridLayoutFormat();
//Set paginate bounds
format.PaginateBounds = new Syncfusion.Drawing.RectangleF(0, 15, page.GetClientSize().Width, page.GetClientSize().Height - 15);
//Draw the grid, letting Syncfusion handle pagination.
pdfGrid.Draw(page, new Syncfusion.Drawing.RectangleF(0, 0, page.GetClientSize().Width, page.GetClientSize().Height), format);
//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}
//Close the document.
document.Close(true);