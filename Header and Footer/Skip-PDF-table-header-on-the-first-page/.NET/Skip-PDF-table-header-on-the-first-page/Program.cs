using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System.Data;

// Create a PDF document
using (PdfDocument document = new PdfDocument())
{
    document.PageSettings.Margins.All = 0;
    // Create and populate the product details data source.
    DataTable dataTable = new DataTable();
    dataTable.Columns.Add("Order ID");
    dataTable.Columns.Add("Product Name");

    for (int i = 1; i <= 200; i++)
    {
        dataTable.Rows.Add($"ORD-{i:000}", $"Product {i}");
    }
    // Create a PdfGrid and bind the data source.
    PdfGrid pdfGrid = new PdfGrid { DataSource = dataTable };
    // Apply grid styling.
    pdfGrid.Style.CellPadding = new PdfPaddings(5, 5, 5, 5);
    pdfGrid.Headers[0].Style.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 11, PdfFontStyle.Bold);
    pdfGrid.Headers[0].Style.BackgroundBrush = new PdfSolidBrush(new PdfColor(31, 78, 121));
    pdfGrid.Headers[0].Style.TextBrush = PdfBrushes.White;
    // Define reusable header resources.
    const float headerHeight = 50;
    PdfFont headerFont = new PdfStandardFont(PdfFontFamily.Helvetica, 16, PdfFontStyle.Bold);
    PdfBrush headerBrush = new PdfSolidBrush(new PdfColor(31, 78, 121));
    // Add the first page to the document.
    PdfPage firstPage = document.Pages.Add();
    // Add a custom header to all paginated pages except the first page.
    pdfGrid.BeginPageLayout += (sender, args) =>
    {
        if (args.Page == firstPage)
            return;
        float pageWidth = args.Page.GetClientSize().Width;
        args.Page.Graphics.DrawRectangle(headerBrush, new RectangleF(0, 0, pageWidth, headerHeight));
        args.Page.Graphics.DrawString("Product Details Report Header", headerFont, PdfBrushes.White, new PointF(20, 15));
        args.Bounds = new RectangleF(30, headerHeight + 10, pageWidth - 60, args.Page.GetClientSize().Height - headerHeight - 10);
    };
    // Draw the grid on the first page without reserving header space.
    pdfGrid.Draw(firstPage, new RectangleF(30, 30, firstPage.GetClientSize().Width - 60, firstPage.GetClientSize().Height - 30));
    // Save the PDF document.
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}