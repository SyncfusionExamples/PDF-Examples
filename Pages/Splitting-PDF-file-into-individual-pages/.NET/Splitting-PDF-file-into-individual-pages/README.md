# Split PDF Files

The Syncfusion [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) allows for creating, reading, and editing PDF documents, as well as splitting them into separate files.

## Steps to split PDF files

Step 1: **Create a new project**: Begin by setting up a new C# Console Application project.

Step 2: **Install the NuGet package**: Add the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) package to your project from [NuGet.org](https://www.nuget.org/).

Step 3: **Include necessary namespaces**: In your **Program.cs** file, include the following namespaces:

   ```csharp
   using Syncfusion.Pdf.Parsing;
   using Syncfusion.Pdf;
   ```

Step 4: **Split the PDF file:** Implement the following code in **Program.cs** to split the PDF file:

   ```csharp
   // Create a FileStream object to read the input PDF file
   using (FileStream inputFileStream = new FileStream("Input.pdf", FileMode.Open, FileAccess.Read))
   {
      // Load the PDF document from the input stream
      using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputFileStream))
      {
         // Iterate over each page of the loaded document
         for (int pageIndex = 0; pageIndex < loadedDocument.PageCount; pageIndex++)
         {
            // Create a new PdfDocument for the output
            using (PdfDocument outputDocument = new PdfDocument())
            {
               // Import the page into the new document
               outputDocument.ImportPage(loadedDocument, pageIndex);

               // Create a FileStream to write the output PDF file
               using (FileStream outputFileStream = new FileStream($"Output{pageIndex}.pdf", FileMode.Create, FileAccess.Write))
               {
                  // Save the new document to the output stream
                  outputDocument.Save(outputFileStream);
               }
            }
         }
      }
   }
   ```

You can download a complete working sample from [GitHub repository](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Pages/Splitting-PDF-file-into-individual-pages/).

To explore additional features of the Syncfusion PDF library, click [here](https://www.syncfusion.com/document-processing/pdf-framework/net-core).