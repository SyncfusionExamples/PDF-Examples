# Merging PDF Files

The Syncfusion [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) allows you to easily create, read, edit, and merge PDF documents. This library provides a straightforward way to combine multiple PDF files into a single document.

## Steps to merge PDF files

Follow these steps to merge PDF files using the Syncfusion library:

Step 1: **Create a new project**: Start by creating a new C# Console Application project.

Step 2: **Install the NuGet package**: Reference the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) package in your project from [NuGet.org](https://www.nuget.org/).

Step 3: **Include required namespaces**: Add the following namespace in your `Program.cs` file:

   ```csharp
   using Syncfusion.Pdf;
   ```

Step 4: **Merge PDF files**: Use the following code snippet in `Program.cs` to merge PDF files:

   ```csharp
   // Create a PDF document for the final merged output
   using (PdfDocument finalDocument = new PdfDocument())
   {
       // Open streams for existing PDF documents
       using (FileStream firstFileStream = new FileStream("File1.pdf", FileMode.Open, FileAccess.Read))
       using (FileStream secondFileStream = new FileStream("File2.pdf", FileMode.Open, FileAccess.Read))
       {
           // Create an array of streams to merge
           Stream[] streams = { firstFileStream, secondFileStream };

           // Merge PDF documents into the final document
           PdfDocumentBase.Merge(finalDocument, streams);

           // Save the merged document to a file stream
           using (FileStream outputFileStream = new FileStream("MergedDocument.pdf", FileMode.Create, FileAccess.Write))
           {
               finalDocument.Save(outputFileStream);
           }
       }
   }
   ```

You can download a complete working sample from the [GitHub repository](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Merge%20PDFs/Merge-multiple-documents-from-stream/).

To explore additional features of the Syncfusion PDF library, click [here](https://www.syncfusion.com/document-processing/pdf-framework/net-core).