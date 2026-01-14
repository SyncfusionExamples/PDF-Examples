# Compressing PDF Files

The Syncfusion<sup>&reg;</sup> [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) allows users to seamlessly create, read, and edit PDF documents. Additionally, it offers features for compressing PDF files, which helps reduce their size without sacrificing quality—optimizing storage and enhancing the efficiency of file sharing.

## Steps to compress PDF files

Follow these steps to compress PDF files using the Syncfusion&reg; library:

Step 1: **Create a new project**: Set up a new C# Console Application project.

Step 2: **Install the NuGet package**: Add the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) package to your project from [NuGet.org](https://www.nuget.org/).

Step 3: **Add required namespaces**: Include the following namespaces in your `Program.cs` file:

```csharp
   using Syncfusion.Pdf.Parsing;
   using Syncfusion.Pdf;
```

Step 4: **Implement PDF compression**: Use the following code snippet in `Program.cs` to compress PDF files:

```csharp
 //Load the PDF document
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Create a new PdfCompressionOptions object
    PdfCompressionOptions options = new PdfCompressionOptions();
    //Set the image quality
    options.ImageQuality = 50;
    // Compress the PDF document
    loadedDocument.Compress(options);
    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
```

You can download a complete working sample from the [GitHub repository](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Compression/Compress-the-existing-PDF-document).

More information about the compressing PDF can be found in this [documentation](https://help.syncfusion.com/document-processing/pdf/pdf-library/net/working-with-compression) section.