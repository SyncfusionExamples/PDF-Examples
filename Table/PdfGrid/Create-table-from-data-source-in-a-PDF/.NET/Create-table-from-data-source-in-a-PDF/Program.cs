using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;

// Create a new PDF document
using (PdfDocument document = new PdfDocument())
{
    //Add a page to the document
    PdfPage page = document.Pages.Add();
    // Create a PdfGrid
    PdfGrid pdfGrid = new PdfGrid();
    // Add values to the list
    List<object> data = new List<object>
       {
           new { ID = "E01", Name = "Clay" },
           new { ID = "E02", Name = "Thomas" },
           new { ID = "E03", Name = "John" }
       };
    // Assign the data source to the grid
    pdfGrid.DataSource = data;
    // Draw the grid on the PDF page
    pdfGrid.Draw(page, new PointF(10, 10));
    // Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}