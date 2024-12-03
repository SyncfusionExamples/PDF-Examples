# Compress PDF Files

The Syncfusion [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) enables users to create, read, and edit PDF documents effortlessly. In addition to these features, the library provides functionality for compressing PDF files, reducing their size without compromising quality, to optimize storage and enhance file sharing efficiency.

## Steps to compress PDF files.

Step 1:  Create a new C# Console Application project.

Step 2: Install the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) NuGet package as reference to your .NET Standard applications from [NuGet.org](https://www.nuget.org/).

Step 3: Include the following namespaces in the **Program.cs** file.

```
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;

```

Step 4: Include the below code snippet in **Program.cs** to compress PDF files.
```
// Open a file stream to read the input PDF file.
using (FileStream fileStream = new FileStream("Input.pdf", FileMode.Open, FileAccess.Read))
{ 
    // Create a new PdfLoadedDocument object from the file stream.
    using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(fileStream))
    { 
        // Create a new PdfCompressionOptions object.
        PdfCompressionOptions options = new PdfCompressionOptions(); 
        // Enable image compression and set image quality.
        options.CompressImages = true; 
        options.ImageQuality = 50; 
        // Enable font optimization.
        options.OptimizeFont = true; 
        
        // Enable page content optimization.
        options.OptimizePageContents = true; 
        // Remove metadata from the PDF.
        options.RemoveMetadata = true; 
        // Compress the PDF document.
        loadedDocument.Compress(options); 
        
        // Save the document into a memory stream.
        using (MemoryStream outputStream = new MemoryStream()) 
        { 
            loadedDocument.Save(outputStream); 
        } 
    } 
}

```

You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Compression/Compress-the-images-in-an-existing-PDF-document).

Click [here](https://www.syncfusion.com/document-processing/pdf-framework/net-core) to explore the rich set of Syncfusion PDF library features.