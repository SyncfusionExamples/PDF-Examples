# Compressing PDF Files

The Syncfusion [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) allows users to seamlessly create, read, and edit PDF documents. Additionally, it offers features for compressing PDF files, which helps reduce their size without sacrificing quality—optimizing storage and enhancing the efficiency of file sharing.

## Steps to compress PDF files

Follow these steps to compress PDF files using the Syncfusion library:

Step 1: **Create a new project**: Set up a new C# Console Application project.

Step 2: **Install the NuGet package**: Add the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) package to your project from [NuGet.org](https://www.nuget.org/).

Step 3: **Add required namespaces**: Include the following namespaces in your `Program.cs` file:

   ```csharp
   using Syncfusion.Pdf.Parsing;
   using Syncfusion.Pdf;
   ```

Step 4: **Implement PDF compression**: Use the following code snippet in `Program.cs` to compress PDF files:

   ```csharp
   // Open a file stream to read the input PDF file
   using (FileStream fileStream = new FileStream("Input.pdf", FileMode.Open, FileAccess.Read))
   {
       // Load the PDF document from the file stream
       using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(fileStream))
       {
           // Create a new PdfCompressionOptions object
           PdfCompressionOptions options = new PdfCompressionOptions();
           
           // Enable image compression and set the image quality
           options.CompressImages = true;
           options.ImageQuality = 50;
           
           // Enable font optimization
           options.OptimizeFont = true;
           
           // Enable page content optimization
           options.OptimizePageContents = true;
           
           // Remove metadata from the PDF
           options.RemoveMetadata = true;
           
           // Compress the PDF document
           loadedDocument.Compress(options);
           
           // Save the document into a memory stream
           using (MemoryStream outputStream = new MemoryStream())
           {
               loadedDocument.Save(outputStream);
           }
       }
   }
   ```

You can download a complete working sample from the [GitHub repository](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Compression/Compress-the-images-in-an-existing-PDF-document).

To explore more features of the Syncfusion PDF library, click [here](https://www.syncfusion.com/document-processing/pdf-framework/net-core).