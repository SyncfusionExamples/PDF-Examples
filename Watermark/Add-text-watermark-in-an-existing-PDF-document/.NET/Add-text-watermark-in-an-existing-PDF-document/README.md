# Edit PDF Files

The Syncfusion [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) is used to create, read, and edit PDF documents. This library also offers functionality to modify existing PDF files, including updating text, images, and other content.

## Steps to edit PDF files.

Step 1:  Create a new C# Console Application project.

Step 2: Install the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) NuGet package as reference to your .NET Standard applications from [NuGet.org](https://www.nuget.org/).

Step 3: Include the following namespaces in the **Program.cs** file.

```
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

```

Step 4: Include the below code snippet in **Program.cs** to edit PDF files.
```
// Create FileStream object to read the input PDF file
using (FileStream inputFileStream = new FileStream("input.pdf", FileMode.Open, FileAccess.Read))
{
    // Load the PDF document from the input stream
    using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputFileStream))
    {
        // Get the first page of the PDF document
        PdfPageBase loadedPage = loadedDocument.Pages[0];
        // Create a PDF font to add a watermark text.
        PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 32);
        // Measure the watermark text and get the size
        string watermarkText = "Created using Syncfusion PDF library";
        SizeF watermarkTextSize = font.MeasureString(watermarkText);

        // Move the graphics to the center of the page
        loadedPage.Graphics.Save();
        loadedPage.Graphics.TranslateTransform(loadedPage.Size.Width / 2, loadedPage.Size.Height / 2);
        // Rotate the graphics to 45 degrees
        loadedPage.Graphics.RotateTransform(-45);
        // Draw the watermark text
        loadedPage.Graphics.DrawString(watermarkText, font, PdfBrushes.Red, new PointF(-watermarkTextSize.Width / 2, -watermarkTextSize.Height / 2));
        // Restore the graphics
        loadedPage.Graphics.Restore();

        using (FileStream outputStream = new FileStream("output.pdf", FileMode.Create, FileAccess.Write))
        {
            // Save the document
            loadedDocument.Save(outputStream);
        }
    }
}

```

You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Watermark/Add-text-watermark-in-an-existing-PDF-document/.NET).

Click [here](https://www.syncfusion.com/document-processing/pdf-framework/net-core) to explore the rich set of Syncfusion PDF library features.