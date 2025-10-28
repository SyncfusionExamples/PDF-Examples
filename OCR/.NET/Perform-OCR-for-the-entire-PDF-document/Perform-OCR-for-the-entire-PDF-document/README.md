# OCR on PDF Files

The Syncfusion<sup>&reg;</sup> [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) enables you to create, read, and edit PDF documents effortlessly. Additionally, the library provides OCR (Optical Character Recognition) capabilities, allowing you to extract text from scanned images within PDF files.

## Steps to perform OCR on PDF files

Follow these steps to apply OCR to PDF files using the Syncfusion<sup>&reg;</sup> library:

Step 1: **Create a new project**: Set up a new C# Console Application project.

Step 2: **Install the NuGet package**: Add the [Syncfusion.PDF.OCR.Net.Core](https://www.nuget.org/packages/Syncfusion.PDF.OCR.Net.Core) package as a reference in your project from [NuGet.org](https://www.nuget.org/).

Step 3: **Include necessary namespaces**: Add the following namespaces in your `Program.cs` file:

```csharp
using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Parsing;
```

Step 4: **Implement OCR Processing**: Use the following code snippet in `Program.cs` to perform OCR on a PDF document:

```csharp
// Initialize the OCR processor
using (OCRProcessor processor = new OCRProcessor())
{
    // Load the PDF document
    using (PdfLoadedDocument pdfLoadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
    {
        // Set OCR language to process
        processor.Settings.Language = Languages.English;
        // Process OCR by providing the PDF document
        processor.PerformOCR(pdfLoadedDocument);
        //Save the PDF document
        pdfLoadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
    }
}
```

For a complete working sample, you can download the example from the [GitHub repository](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/OCR/.NET/Perform-OCR-for-the-entire-PDF-document).

More information about the OCR on PDF can be found in this [documentation](https://help.syncfusion.com/document-processing/pdf/pdf-library/net/working-with-ocr/features) section.