# Extract Data from PDF

The Syncfusion<sup>&reg;</sup> [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) enables the creation, reading, and editing of PDF documents. Additionally, it provides capabilities to extract data from PDFs, such as text, images, and form field values.

## Steps to Extract Data from PDF Files

Step 1: **Create a new project**: Begin by setting up a new C# Console Application project.

Step 2: **Install the NuGet package**: Add the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) package to your project from [NuGet.org](https://www.nuget.org/).

Step 3: **Include necessary namespaces**: Add these namespaces in your **Program.cs** file:

```csharp
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
```

Step 4: **Extract data from PDF**: Use the following code in **Program.cs** to extract data from a PDF:

```csharp
// Load the PDF document
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Initialize an empty string to store extracted text
    string extractedText = string.Empty;
    // Extract text from each page in the document
    foreach (PdfLoadedPage page in loadedDocument.Pages)
    {
        extractedText += page.ExtractText();
    }
    // Display the extracted text in the console
    Console.WriteLine("Extracted text from the entire document: " + extractedText);
}
```

For a complete working example, download it from [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Text%20Extraction/Extract-text-from-the-entire-PDF-document/).

More information about the extract data can be found in this [documentation](https://help.syncfusion.com/document-processing/pdf/pdf-library/net/working-with-text-extraction) section.