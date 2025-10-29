# Merging PDF Files

The Syncfusion<sup>&reg;</sup> [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) allows you to easily create, read, edit, and merge PDF documents. This library provides a straightforward way to combine multiple PDF files into a single document.

## Steps to merge PDF files

Follow these steps to merge PDF files using the Syncfusion<sup>&reg;</sup> library:

Step 1: **Create a new project**: Start by creating a new C# Console Application project.

Step 2: **Install the NuGet package**: Reference the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) package in your project from [NuGet.org](https://www.nuget.org/).

Step 3: **Include required namespaces**: Add the following namespace in your `Program.cs` file:

```csharp
using Syncfusion.Pdf;
```

Step 4: **Merge PDF files**: Use the following code snippet in `Program.cs` to merge PDF files:

```csharp
//Creates a new PDF document
using (PdfDocument document = new PdfDocument())
{
    //Creates a string array of source files to be merged
    string[] source = { Path.GetFullPath(@"Data/file1.pdf"), Path.GetFullPath(@"Data/file2.pdf") };
    //Merge PDF documents
    PdfDocument.Merge(document, source);
    //Saves the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
```

You can download a complete working sample from the [GitHub repository](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Merge%20PDFs/Merge-multiple-documents-from-stream/).

More information about the merge PDF can be found in this [documentation](https://help.syncfusion.com/document-processing/pdf/pdf-library/net/merge-documents) section.