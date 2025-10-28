# Redacting PDF Files

The Syncfusion<sup>&reg;</sup> [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) allows users to create, read, and edit PDFs seamlessly. One of its key features is the ability to redact PDF content, enabling the permanent removal or hiding of sensitive information while maintaining the rest of the document's integrity.

## Steps to Redact PDF Files

Step 1: **Create a new project**: Start by creating a new C# Console Application project.

Step 2: **Install the NuGet package**: Add the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) package to your project via [NuGet.org](https://www.nuget.org/).

Step 3: **Include necessary namespaces**: Add these namespaces to your **Program.cs** file:

```csharp
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;
```

Step 4: **Implement redaction**: Use the following code in **Program.cs** to perform PDF redaction:

```csharp
//Load the PDF document
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Get the first page of the document
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;
    // Define a redaction area and set its color to black
    PdfRedaction redaction = new PdfRedaction(new RectangleF(340, 120, 140, 20), Color.Black);
    // Add the redaction to the page
    loadedPage.AddRedaction(redaction);
    // Apply the redaction to remove content
    loadedDocument.Redact();
    // Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
```

You can download a complete working example from [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Redaction/Removing-sensitive-content-from-the-PDF-document/).

More information about the redacting PDF can be found in this [documentation](https://help.syncfusion.com/document-processing/pdf/pdf-library/net/working-with-redaction) section.