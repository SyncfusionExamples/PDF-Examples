using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    // Add a page
    PdfPage page = document.Pages.Add();

    //Create a PdfGrid.
    PdfGrid pdfGrid = new PdfGrid();
    // Create a list with multiple short rows and one very large row
    var data = new List<object>
            {
                new { ID = "E01", Description = "Short text 1" },
                new { ID = "E02", Description = "Short text 2" },
                new
                {
                    ID = "E03",
                    Description = new string('A', 5000)
                },
                new { ID = "E04", Description = "Short text 3" }
            };

    // Assign the list as the data source
    pdfGrid.DataSource = data;

    // Prevent row breaking across pages
    pdfGrid.AllowRowBreakAcrossPages = false;

    // Draw the grid on the page
    pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(0, 0));

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
