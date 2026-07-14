using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Parsing;
using System.Data;

//Create a new PDF document.
PdfDocument finalDocumentSettings = new PdfDocument();
finalDocumentSettings.PageSettings.Margins.All = 0;
PdfPage page = finalDocumentSettings.Pages.Add();
PointF pdfGridLocation = new PointF(0, 100);

// Create PdfGrid
PdfGrid pdfGrid = new PdfGrid();
DataTable dataTable = new DataTable();
dataTable.Columns.Add("ID");
dataTable.Columns.Add("Table Name");
for (int i = 1; i <= 200; i++)
{
    dataTable.Rows.Add($"E-{i}", $"PDF Table - {i}");
}
pdfGrid.DataSource = dataTable;

// Step 1 - Draw PdfGrid with Header
RectangleF headerBounds = new RectangleF(0, 0, PdfPageSize.A4.Width, 50);
PdfPageTemplateElement header = new PdfPageTemplateElement(headerBounds);
header.Graphics.DrawString("Header", new PdfStandardFont(PdfFontFamily.TimesRoman, 16), PdfBrushes.Black, new PointF((PdfPageSize.A4.Width / 2) - 20, 0));
finalDocumentSettings.Template.Top = header;
pdfGrid.Draw(page, new RectangleF(30, pdfGridLocation.Y - headerBounds.Height, 550, PdfPageSize.A4.Height));
using MemoryStream finalDocumentMS = new MemoryStream();
finalDocumentSettings.Save(finalDocumentMS);
finalDocumentSettings.Close(true);

// Step 2 - Draw PdfGrid without Header
PdfDocument tempDocument = new PdfDocument();
// Copy the same page settings
tempDocument.PageSettings.Size = finalDocumentSettings.PageSettings.Size;
tempDocument.PageSettings.Orientation = finalDocumentSettings.PageSettings.Orientation;
tempDocument.PageSettings.Margins.All = 0;
PdfPage tempPage = tempDocument.Pages.Add();
pdfGrid.Draw(tempPage, new RectangleF(30, pdfGridLocation.Y, 550, PdfPageSize.A4.Height));
using MemoryStream tempDocumentMS = new MemoryStream();
tempDocument.Save(tempDocumentMS);
tempDocument.Close(true);

// Step 3 - Replace First Page
finalDocumentMS.Position = 0;
tempDocumentMS.Position = 0;
PdfLoadedDocument finalDocument = new PdfLoadedDocument(finalDocumentMS);
PdfLoadedDocument tempLoadedDocument = new PdfLoadedDocument(tempDocumentMS);
finalDocument.Pages.RemoveAt(0);
finalDocument.Pages.Insert(0, tempLoadedDocument.Pages[0]);
// Save output
finalDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
tempLoadedDocument.Close(true);
finalDocument.Close(true);