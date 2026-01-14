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
        new { ID = "E01", Name = "Clay" },
        new { ID = "E02", Name = "Thomas" },
        new { ID = "E03", Name = "John" }
    };
    // Assign the data source to the grid
    pdfGrid.DataSource = data;
    // Access the auto-generated header row and set custom column names
    PdfGridRow header = pdfGrid.Headers[0];
    header.Cells[0].Value = "ID";
    header.Cells[1].Value = "Name";
    // Define padding and font for header and body cells
    PdfPaddings paddings = new PdfPaddings(10, 8, 10, 8);
    PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Bold);
    // Create header style
    PdfGridCellStyle headerStyle = new PdfGridCellStyle
    {
        CellPadding = paddings,
        TextBrush = new PdfSolidBrush(Color.White),
        BackgroundBrush = new PdfSolidBrush(Color.Blue),
        Font = font
    };
    // Apply the header style to the header row
    pdfGrid.Headers[0].ApplyStyle(headerStyle);
    // Apply padding and font style to body cells
    pdfGrid.Style.CellPadding = paddings;
    pdfGrid.Style.Font = font;
    // Draw the grid on the PDF page at specified position
    pdfGrid.Draw(page, new PointF(20, 40));
    // Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}