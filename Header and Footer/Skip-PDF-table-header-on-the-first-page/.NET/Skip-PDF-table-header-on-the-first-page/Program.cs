using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Parsing;
using System.Data;

// Create PDF document
PdfDocument document = new PdfDocument();
document.PageSettings.Size = PdfPageSize.A4;
document.PageSettings.Margins.All = 0;
// Create data source
DataTable dataTable = new DataTable();
dataTable.Columns.Add("Order ID");
dataTable.Columns.Add("Product Name");
for (int i = 1; i <= 200; i++)
{
    dataTable.Rows.Add($"ORD-{i:000}", $"Product {i}");
}
// Create PdfGrid
PdfGrid pdfGrid = new PdfGrid();
pdfGrid.DataSource = dataTable;
// Apply grid styling
pdfGrid.Style.CellPadding = new PdfPaddings(5, 5, 5, 5);
pdfGrid.Headers[0].Style.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 11, PdfFontStyle.Bold);
pdfGrid.Headers[0].Style.BackgroundBrush = new PdfSolidBrush(new PdfColor(31, 78, 121));
pdfGrid.Headers[0].Style.TextBrush = PdfBrushes.White;
// Create page header template
RectangleF headerBounds = new RectangleF(0, 0, PdfPageSize.A4.Width, 50);
PdfPageTemplateElement headerTemplate = new PdfPageTemplateElement(headerBounds);
headerTemplate.Graphics.DrawRectangle(new PdfSolidBrush(new PdfColor(31, 78, 121)), headerBounds);
headerTemplate.Graphics.DrawString("Product Details Report", new PdfStandardFont(PdfFontFamily.Helvetica, 16, PdfFontStyle.Bold), PdfBrushes.White, new PointF(20, 15));
document.Template.Top = headerTemplate;
// Draw grid with header template
PdfPage page = document.Pages.Add();
pdfGrid.Draw(page, new RectangleF(30, 50, page.GetClientSize().Width - 60, page.GetClientSize().Height));
// Save document with header
MemoryStream documentStream = new MemoryStream();
document.Save(documentStream);
document.Close(true);
// Create temporary document without header
PdfDocument tempDocument = new PdfDocument();
tempDocument.PageSettings.Size = PdfPageSize.A4;
tempDocument.PageSettings.Margins.All = 0;
PdfPage tempPage = tempDocument.Pages.Add();
pdfGrid.Draw(tempPage, new RectangleF(30, 100, tempPage.GetClientSize().Width - 60, tempPage.GetClientSize().Height));
MemoryStream tempStream = new MemoryStream();
tempDocument.Save(tempStream);
tempDocument.Close(true);
// Replace the first page
documentStream.Position = 0;
tempStream.Position = 0;
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(documentStream);
PdfLoadedDocument loadedTempDocument = new PdfLoadedDocument(tempStream);
loadedDocument.Pages.RemoveAt(0);
loadedDocument.Pages.Insert(0, loadedTempDocument.Pages[0]);
// Save the result
loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
loadedTempDocument.Close(true);
loadedDocument.Close(true);