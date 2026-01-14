# PDF Tables

The Syncfusion&reg; [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) facilitates the creation, reading, and editing of PDF documents. It also provides features to create and customize tables within PDF files, allowing for efficient data organization and presentation.

## Steps to Add a Table to a PDF Document

Step 1: **Create a new project**: Start by setting up a new C# Console Application project.

Step 2: **Install the NuGet package**: Reference the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) package in your project from [NuGet.org](https://www.nuget.org/).

Step 3: **Include necessary namespaces**: Add these namespaces to your **Program.cs** file:

```csharp
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
```

Step 4: **Add a table to the PDF**: Use the following code in **Program.cs** to insert a table into the PDF:

```csharp
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
```

A complete working example is available on [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Table/PdfGrid/Create-table-from-data-source-in-a-PDF/.NET).

More information about the PDF tables can be found in this [documentation](https://help.syncfusion.com/document-processing/pdf/pdf-library/net/working-with-tables) section.