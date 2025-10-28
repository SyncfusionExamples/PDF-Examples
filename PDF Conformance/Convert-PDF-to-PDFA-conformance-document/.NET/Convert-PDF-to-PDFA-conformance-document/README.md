# Convert PDF to PDF/A

The Syncfusion<sup>&reg;</sup> [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) provides tools for creating, reading, and editing PDF documents. Among its features, the library enables conversion of standard PDF files into the PDF/A format, suitable for long-term archiving and meeting archival standards.

## Steps to convert a PDF to PDF/A

Follow these steps to convert a PDF document to PDF/A format using the Syncfusion<sup>&reg;</sup> library:

Step 1: **Create a new project**: Start by creating a new C# Console Application project.

Step 2: **Install the NuGet package**: Reference the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) package in your project from [NuGet.org](https://www.nuget.org/).

Step 3: **Include necessary namespaces**: Add the following namespaces in your `Program.cs` file:

```csharp
using SkiaSharp;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
```

Step 4: **Convert PDF to PDF/A**: Implement the following code in `Program.cs` to perform the conversion:

```csharp
// Load the PDF document
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Handle font substitution during PDF/A conversion
    loadedDocument.SubstituteFont += LoadedDocument_SubstituteFont;
    // Convert the document to PDF/A-1B format
    loadedDocument.ConvertToPDFA(PdfConformanceLevel.Pdf_A1B);
    // Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

// Event handler to substitute missing fonts during conversion
void LoadedDocument_SubstituteFont(object sender, PdfFontEventArgs args)
{
    // Extract the font name (ignoring style suffixes)
    string fontName = args.FontName.Split(',')[0];
    // Determine the font style
    PdfFontStyle fontStyle = args.FontStyle;
    SKFontStyle skFontStyle = SKFontStyle.Normal;
    // Map PDF font styles to SkiaSharp font styles
    if (fontStyle == PdfFontStyle.Bold)
        skFontStyle = SKFontStyle.Bold;
    else if (fontStyle == PdfFontStyle.Italic)
        skFontStyle = SKFontStyle.Italic;
    else if (fontStyle == (PdfFontStyle.Bold | PdfFontStyle.Italic))
        skFontStyle = SKFontStyle.BoldItalic;
    // Load the typeface using SkiaSharp
    SKTypeface typeface = SKTypeface.FromFamilyName(fontName, skFontStyle);
    SKStreamAsset typeFaceStream = typeface.OpenStream();

    // Create a memory stream from the font data
    MemoryStream memoryStream = null;
    if (typeFaceStream != null && typeFaceStream.Length > 0)
    {
        byte[] fontData = new byte[typeFaceStream.Length];
        typeFaceStream.Read(fontData, fontData.Length);
        typeFaceStream.Dispose();
        memoryStream = new MemoryStream(fontData);
    }
    // Assign the font stream to the event arguments
    args.FontStream = memoryStream;
}
```

You can download a complete working sample from the [GitHub repository](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/PDF%20Conformance/Convert-PDF-to-PDFA-conformance-document).

More information about the PDF conformance can be found in this [documentation](https://help.syncfusion.com/document-processing/pdf/pdf-library/net/working-with-pdf-conformance) section.