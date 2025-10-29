# Create PDF Document

The Syncfusion<sup>&reg;</sup> [.NET PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net/pdf-library) used to create PDF document from scratch and saving it to disk or stream. This library also offers functionality to merge, split, stamp, forms, and secure PDF files.

## Steps to create PDF document

Follow these steps to crating a PDF using the Syncfusion<sup>&reg;</sup> library:

Step 1: **Create a new project**: Start by creating a new C# Console Application project.

Step 2: **Install the NuGet package**: Reference the [Syncfusion.Pdf.NET](https://www.nuget.org/packages/Syncfusion.Pdf.Net) package in your project from [NuGet.org](https://www.nuget.org/).

Step 3: **Include required namespaces**: Add the following namespace in your `Program.cs` file:

```csharp
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
```

Step 4: **Create PDF document**: Use the following code snippet in `Program.cs` to merge PDF files:

```csharp
//Create a new PDF document
using (PdfDocument document = new PdfDocument())
{
    //Add a page to the document
    PdfPage page = document.Pages.Add();
    // Create a standard font
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
    //Draw the text using page graphics
    page.Graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));
    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
```

You can download a complete working sample from the [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Getting%20Started/.NET/Create_PDF_NET).

More information about the creating a PDF can be found in this [documentation](https://help.syncfusion.com/document-processing/pdf/pdf-library/net/create-pdf-file-in-c-sharp-vb-net) section.