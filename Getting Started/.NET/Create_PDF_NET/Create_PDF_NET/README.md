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
```

Step 4: **Create PDF document**: Use the following code snippet in `Program.cs` to merge PDF files:

```csharp
//Create a new PDF document.
PdfDocument document = new PdfDocument();
//Add a page to the document.
PdfPage page = document.Pages.Add();
//Create PDF graphics for the page.
PdfGraphics graphics = page.Graphics;
//Set the standard font.
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
//Draw the text.
graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(0, 0));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}
//Close the document.
document.Close(true);
```

You can download a complete working sample from the [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Getting%20Started/.NET/Create_PDF_NET).

More information about the merge PDF can be found in this [documentation](https://help.syncfusion.com/document-processing/pdf/pdf-library/net/create-pdf-file-in-c-sharp-vb-net) section.