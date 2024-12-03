# Convert PDF to PDF/A

The Syncfusion [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) is used to create, read, and edit PDF documents. This library also offers functionality to convert standard PDF files into PDF/A format for long-term archiving and compliance with archival standards.

## Steps to convert PDF to PDF/A

Step 1:  Create a new C# Console Application project.

Step 2: Install the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) NuGet package as reference to your .NET Standard applications from [NuGet.org](https://www.nuget.org/).

Step 3: Include the following namespaces in the **Program.cs** file.

```
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

```

Step 4: Include the below code snippet in **Program.cs** to convert PDF to PDF/A files.
```
// Load an existing PDF document
using (FileStream inputPdfStream = new FileStream("Input.pdf", FileMode.Open, FileAccess.Read))
{
    // Initialize PdfLoadedDocument with the input file stream
    PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputPdfStream);
    // Convert the loaded document to PDF/A format with specified conformance level
    loadedDocument.ConvertToPDFA(PdfConformanceLevel.Pdf_A1B);

    // Save the converted PDF/A document to a new file
    using (FileStream outputPdfStream = new FileStream("Output.pdf", FileMode.Create, FileAccess.Write))
    {
        // Save the modified PDF document to the output file stream
        loadedDocument.Save(outputPdfStream);
    }
    // Close the loaded document to release resources
    loadedDocument.Close(true);
}

```

You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/PDF%20Conformance/Get-PDF-to-PDFA-conversion-progress/.NET).

Click [here](https://www.syncfusion.com/document-processing/pdf-framework/net-core) to explore the rich set of Syncfusion PDF library features.