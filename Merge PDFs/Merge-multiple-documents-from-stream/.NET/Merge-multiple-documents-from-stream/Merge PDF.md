# Merge PDF Files

The Syncfusion [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) enables users to create, read, and edit PDF documents with ease. Additionally, this library provides functionality for merging multiple PDF files into a single document.

## Steps to merge PDF files.

Step 1:  Create a new C# Console Application project.

Step 2: Install the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) NuGet package as reference to your .NET Standard applications from [NuGet.org](https://www.nuget.org/).

Step 3: Include the following namespaces in the **Program.cs** file.


```
using Syncfusion.Pdf;

```

Step 4: Include the below code snippet in **Program.cs** to merge PDF files.
```
// Create a PDF document.
using (PdfDocument finalDocument = new PdfDocument())
{
    // Get the stream from an existing PDF documents.
    using (FileStream firstFileStream = new FileStream("File1.pdf", FileMode.Open, FileAccess.Read))
    using (FileStream secondFileStream = new FileStream("File2.pdf", FileMode.Open, FileAccess.Read))
    {
        // Create an array of streams for merging.
        Stream[] streams = { firstFileStream, secondFileStream };

        // Merge PDF documents.
        PdfDocumentBase.Merge(finalDocument, streams);

        // Save the merged document into a file stream.
        using (FileStream outputFileStream = new FileStream("MergedDocument.pdf", FileMode.Create, FileAccess.Write))
        {
            finalDocument.Save(outputFileStream);
        }
    }
}

```

You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Merge%20PDFs/Merge-multiple-documents-from-stream/).

Click [here](https://www.syncfusion.com/document-processing/pdf-framework/net-core) to explore the rich set of Syncfusion PDF library features.