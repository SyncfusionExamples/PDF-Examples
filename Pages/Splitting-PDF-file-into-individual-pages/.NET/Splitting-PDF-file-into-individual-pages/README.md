# Split PDF Files

The Syncfusion<sup>&reg;</sup> [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) allows for creating, reading, and editing PDF documents, as well as splitting them into separate files.

## Steps to split PDF files

Step 1: **Create a new project**: Begin by setting up a new C# Console Application project.

Step 2: **Install the NuGet package**: Add the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) package to your project from [NuGet.org](https://www.nuget.org/).

Step 3: **Include necessary namespaces**: In your **Program.cs** file, include the following namespaces:

```csharp
using Syncfusion.Pdf.Parsing;
```

Step 4: **Split the PDF file:** Implement the following code in **Program.cs** to split the PDF file:

```csharp
//Load the PDF document
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Split the pages into separate documents
    loadedDocument.Split("Output" + "{0}.pdf");
}
```

You can download a complete working sample from [GitHub repository](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Pages/Splitting-PDF-file-into-individual-pages/).

More information about the split PDF can be found in this [documentation](https://help.syncfusion.com/document-processing/pdf/pdf-library/net/split-documents) section.