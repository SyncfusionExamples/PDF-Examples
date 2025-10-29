# Edit PDF Files

The Syncfusion<sup>&reg;</sup> [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) provides tools for creating, reading, and editing PDF documents. It also supports modifying existing PDF files, including updating text, images, and other content.

## Steps to Add a Watermark to a PDF File

Step 1: **Create a new project**: Begin by setting up a new C# Console Application project.

Step 2: **Install the NuGet package**: Add the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) package to your project from [NuGet.org](https://www.nuget.org/).

Step 3: **Include necessary namespaces**: Include the following namespaces in your **Program.cs** file:

```csharp
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
```

Step 4: **Add a watermark to the PDF**: Use the following code snippet in **Program.cs** to apply a watermark to an existing PDF:

```csharp
//Load the PDF document
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Get the first page of the PDF document
    PdfPageBase loadedPage = loadedDocument.Pages[0];
    //Create the standard font
    PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 32);
    // Measure the watermark text and get the size
    string watermarkText = "Created using Syncfusion PDF library";
    SizeF watermarkTextSize = font.MeasureString(watermarkText);
    // Move the graphics to the center of the page
    loadedPage.Graphics.Save();
    loadedPage.Graphics.TranslateTransform(loadedPage.Size.Width / 2, loadedPage.Size.Height / 2);
    // Rotate the graphics to 45 degrees
    loadedPage.Graphics.RotateTransform(-45);
    //Set transparency
    loadedPage.Graphics.SetTransparency(0.25f);
    // Draw the watermark text
    loadedPage.Graphics.DrawString(watermarkText, font, PdfBrushes.Red, new PointF(-watermarkTextSize.Width / 2, -watermarkTextSize.Height / 2));
    // Restore the graphics
    loadedPage.Graphics.Restore();
    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
```

You can download a complete working example from [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Watermark/Add-text-watermark-in-an-existing-PDF-document/.NET).

More information about the edit PDF can be found in this [documentation](https://help.syncfusion.com/document-processing/pdf/pdf-library/net/working-with-watermarks) section.