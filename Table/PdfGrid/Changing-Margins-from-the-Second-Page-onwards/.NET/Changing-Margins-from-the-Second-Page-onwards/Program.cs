using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    // Configure marginless page layout
    document.PageSettings.Margins.Top = 0;
    document.PageSettings.Margins.Bottom = 0;

    // Add first page to the document
    PdfPage page = document.Pages.Add();

    // Initialize grid component for data presentation
    PdfGrid pdfGrid = new PdfGrid();

    // Generate sample data (300 rows)
    List<object> data = new List<object>();
    for (int i = 0; i < 100; i++)
    {
        // Create three unique rows per iteration
        data.Add(new { ID = "1", Name = "Clay", Price = "$10" });
        data.Add(new { ID = "2", Name = "Gray", Price = "$20" });
        data.Add(new { ID = "3", Name = "Ash", Price = "$30" });
    }

    // Configure grid data binding
    pdfGrid.DataSource = data; // Automatic conversion to IEnumerable

    // Set up grid layout with header space
    PdfGridLayoutFormat format = new PdfGridLayoutFormat
    {
        PaginateBounds = new RectangleF(0, 15,
        page.GetClientSize().Width,
        page.GetClientSize().Height - 15)
    };

    // Render grid to page with automatic pagination
    pdfGrid.Draw(page, new RectangleF(0, 0,
    page.GetClientSize().Width,
    page.GetClientSize().Height), format);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}