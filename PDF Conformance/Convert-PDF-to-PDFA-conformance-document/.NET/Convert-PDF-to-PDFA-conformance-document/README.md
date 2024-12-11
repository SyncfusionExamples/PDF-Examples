# Convert PDF to PDF/A

The Syncfusion [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) provides tools for creating, reading, and editing PDF documents. Among its features, the library enables conversion of standard PDF files into the PDF/A format, suitable for long-term archiving and meeting archival standards.

## Steps to convert a PDF to PDF/A

Follow these steps to convert a PDF document to PDF/A format using the Syncfusion library:

Step 1: **Create a new project**: Start by creating a new C# Console Application project.

Step 2: **Install the NuGet package**: Reference the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) package in your project from [NuGet.org](https://www.nuget.org/).

Step 3: **Include necessary namespaces**: Add the following namespaces in your `Program.cs` file:

   ```csharp
   using Syncfusion.Pdf;
   using Syncfusion.Pdf.Parsing;
   ```

Step 4: **Convert PDF to PDF/A**: Implement the following code in `Program.cs` to perform the conversion:

   ```csharp
   // Load an existing PDF document
   using (FileStream inputPdfStream = new FileStream("Input.pdf", FileMode.Open, FileAccess.Read))
   {
       // Initialize PdfLoadedDocument with the input file stream
       PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputPdfStream);

       // Convert the loaded document to PDF/A format with the specified conformance level
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

You can download a complete working sample from the [GitHub repository](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/PDF%20Conformance/Convert-PDF-to-PDFA-conformance-document).

To explore additional features of the Syncfusion PDF library, click [here](https://www.syncfusion.com/document-processing/pdf-framework/net-core).