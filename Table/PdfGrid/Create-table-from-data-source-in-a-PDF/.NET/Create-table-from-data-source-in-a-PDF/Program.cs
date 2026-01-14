using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;

// Create a new PDF document
using (PdfDocument document = new PdfDocument())
{
    // Add a new page to the PDF document
    PdfPage page = document.Pages.Add();
    // Create a PdfGrid to display tabular data
    PdfGrid pdfGrid = new PdfGrid();
    // Prepare sample data for the grid
    object data = new List<object>
    {
        new { ID = "E01", Name = "Clay", Department = "HR" },
        new { ID = "E02", Name = "Thomas", Department = "Finance" },
        new { ID = "E03", Name = "John", Department = "IT" },
        new { ID = "E04", Name = "Emma", Department = "Marketing" },
        new { ID = "E05", Name = "Sophia", Department = "Operations" }
    };
    // Assign the data source to the grid (auto-generates a header row)
    pdfGrid.DataSource = data;
    //Apply built-in table style
    pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent6);
    // Apply padding and font style to body cells
    pdfGrid.Style.CellPadding = new PdfPaddings(10, 6, 10, 6);
    // Draw the grid on the PDF page at specified position (with margin)
    pdfGrid.Draw(page, new PointF(20, 40));
    // Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}