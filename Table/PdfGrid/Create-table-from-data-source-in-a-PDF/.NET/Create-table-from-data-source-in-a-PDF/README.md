# PDF Tables

The Syncfusion [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) is used to create, read, and edit PDF documents. This library also offers functionality to create and customize tables in PDF files for organizing and presenting data effectively.

## Steps to add a table to a PDF document

Step 1:  Create a new C# Console Application project.

Step 2: Install the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) NuGet package as reference to your .NET Standard applications from [NuGet.org](https://www.nuget.org/).

Step 3: Include the following namespaces in the **Program.cs** file.

```
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

```

Step 4: Include the below code snippet in **Program.cs** to add a table to a PDF files.
```
//Create a new PDF document
using (PdfDocument document = new PdfDocument())
{
    //Add a page
    PdfPage page = document.Pages.Add();
    //Create a PdfGrid
    PdfGrid pdfGrid = new PdfGrid();

    //Add values to the list
    List<object> data = new List<object>();
    data.Add(new { ID = "E01", Name = "Clay" });
    data.Add(new { ID = "E02", Name = "Thomas" });
    data.Add(new { ID = "E03", Name = "John" });

    //Assign the data source
    pdfGrid.DataSource = data;
    //Draw the grid to the page of PDF document
    pdfGrid.Draw(page, new PointF(10, 10));

    using (FileStream outputStream = new FileStream("output.pdf", FileMode.Create, FileAccess.Write))
    {
        //Save the document
        document.Save(outputStream);
    }
}

```

You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Table/PdfGrid/Create-table-from-data-source-in-a-PDF/.NET).

Click [here](https://www.syncfusion.com/document-processing/pdf-framework/net-core) to explore the rich set of Syncfusion PDF library features.