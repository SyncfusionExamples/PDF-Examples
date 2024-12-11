# PDF Tables

The Syncfusion [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) facilitates the creation, reading, and editing of PDF documents. It also provides features to create and customize tables within PDF files, allowing for efficient data organization and presentation.

## Steps to Add a Table to a PDF Document

1. **Create a new project**: Start by setting up a new C# Console Application project.

2. **Install the NuGet package**: Reference the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) package in your project from [NuGet.org](https://www.nuget.org/).

3. **Include necessary namespaces**: Add these namespaces to your **Program.cs** file:

   ```csharp
   using Syncfusion.Pdf.Grid;
   using Syncfusion.Pdf;
   using Syncfusion.Drawing;
   ```

4. **Add a table to the PDF**: Use the following code in **Program.cs** to insert a table into the PDF:

   ```csharp
   // Create a new PDF document
   using (PdfDocument document = new PdfDocument())
   {
       // Add a page
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

       // Assign the data source
       pdfGrid.DataSource = data;

       // Draw the grid on the PDF page
       pdfGrid.Draw(page, new PointF(10, 10));

       using (FileStream outputStream = new FileStream("output.pdf", FileMode.Create, FileAccess.Write))
       {
           // Save the document
           document.Save(outputStream);
       }
   }
   ```

A complete working example is available on [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Table/PdfGrid/Create-table-from-data-source-in-a-PDF/.NET).

Explore more features of the Syncfusion PDF library [here](https://www.syncfusion.com/document-processing/pdf-framework/net-core).