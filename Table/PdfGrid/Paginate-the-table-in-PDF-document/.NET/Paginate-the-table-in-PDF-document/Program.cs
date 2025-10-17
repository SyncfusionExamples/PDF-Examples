using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page
    PdfPage page = document.Pages.Add();

    //Create a PdfGrid
    PdfGrid pdfGrid = new PdfGrid();

    //Add values to list
    List<object> data = new List<object>();

    //You can add multiple rows here
    Object row1 = new { ID = "E01", Name = "Clay" };
    Object row2 = new { ID = "E02", Name = "Thomas" };

    for (int i = 0; i < 500; i++)
    {
        data.Add(row1);
        data.Add(row2);
    }

    //Add list to IEnumerable
    IEnumerable<object> dataTable = data;

    //Assign data source.
    pdfGrid.DataSource = dataTable;

    //Set properties to paginate the grid.
    PdfGridLayoutFormat layoutFormat = new PdfGridLayoutFormat();
    layoutFormat.Break = PdfLayoutBreakType.FitPage;
    layoutFormat.Layout = PdfLayoutType.Paginate;

    //Draw grid to the page of PDF document.
    pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(10, 10), layoutFormat);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

