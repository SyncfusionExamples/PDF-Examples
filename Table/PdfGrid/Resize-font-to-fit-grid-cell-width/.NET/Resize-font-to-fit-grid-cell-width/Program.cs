using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;

class Program
{
    static void Main(string[] args)
    {
        // Create a new PDF document.
        PdfDocument document = new PdfDocument();

        // Add a page to the document.
        PdfPage page = document.Pages.Add();

        // Create a PdfGrid.
        PdfGrid grid = new PdfGrid();

        // Set the font for the grid.
        grid.Style.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);

        // Add three columns to the grid.
        grid.Columns.Add(3);

        // Set the width of each column.
        for (int i = 0; i < 3; i++)
        {
            grid.Columns[i].Width = page.GetClientSize().Width / 3;
        }

        // Set up the header cells.
        PdfGridRow pdfGridHeader = grid.Headers.Add(1)[0];
        pdfGridHeader.Cells[0].Value = "Employee ID";
        pdfGridHeader.Cells[1].Value = "Employee Name";
        pdfGridHeader.Cells[2].Value = "Details";

        // Add rows to the grid.
        for (int i = 0; i < 5; i++)
        {
            PdfGridRow row = grid.Rows.Add();
            row.Height = 20;
            row.Cells[0].Value = "E0" + i;
            row.Cells[1].Value = "Syncfusion PDF library supports to adjust PDF table row width based on the text length";
            row.Cells[2].Value = "Syncfusion PDF library supports to adjust PDF table row width based on the text length by enabling the AllowHorizontalOverflow property in the PDF document using C# and VB.NET";
        }

        // Adjust the font size to fit the cell content.
        AdjustFontSize(grid);

        // Draw the PdfGrid on the page.
        grid.Draw(page, PointF.Empty);

        // Save and close the document.
        using (FileStream stream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
        {
            document.Save(stream);
        }
        document.Close(true);
    }

    // Method to adjust the font size to fit the cell content.
    public static void AdjustFontSize(PdfGrid grid)
    {
        for (int i = 0; i < grid.Rows.Count; i++)
        {
            for (int j = 0; j < grid.Columns.Count; j++)
            {
                // Get the cell.
                PdfGridCell cell = grid.Rows[i].Cells[j];

                // Get the cell font.
                PdfFont initialFont = cell.Style.Font ?? grid.Style.Font;

                // Get the cell value.
                string text = cell.Value?.ToString() ?? string.Empty;

                // Get the cell size.
                SizeF cellSize = new SizeF(grid.Columns[j].Width, grid.Rows[i].Height);

                // Get the initial font size.
                float fontSize = initialFont.Size;

                PdfFont currentFont = initialFont;

                while (fontSize > 0)
                {
                    //Measure the text
                    SizeF textSize = currentFont.MeasureString(text, cellSize.Width);
                    if (textSize.Height <= cellSize.Height)
                    {
                        cell.Style.Font = currentFont;
                        break;
                    }
                    fontSize--;
                    if (initialFont is PdfStandardFont)
                    {
                        currentFont = new PdfStandardFont(initialFont as PdfStandardFont, fontSize);
                    }
                    else
                    {
                        currentFont = new PdfTrueTypeFont(initialFont as PdfTrueTypeFont, fontSize);
                    }
                }
            }
        }
    }
}
