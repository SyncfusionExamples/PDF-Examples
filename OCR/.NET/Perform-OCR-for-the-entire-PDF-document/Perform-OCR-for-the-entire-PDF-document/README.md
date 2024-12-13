# OCR on PDF Files

The Syncfusion [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) enables you to create, read, and edit PDF documents effortlessly. Additionally, the library provides OCR (Optical Character Recognition) capabilities, allowing you to extract text from scanned images within PDF files.

## Steps to perform OCR on PDF files

Follow these steps to apply OCR to PDF files using the Syncfusion library:

Step 1: **Create a new project**: Set up a new C# Console Application project.

Step 2: **Install the NuGet package**: Add the [Syncfusion.PDF.OCR.Net.Core](https://www.nuget.org/packages/Syncfusion.PDF.OCR.Net.Core) package as a reference in your project from [NuGet.org](https://www.nuget.org/).

Step 3: **Include necessary namespaces**: Add the following namespaces in your `Program.cs` file:

   ```csharp
   using Syncfusion.OCRProcessor;
   using Syncfusion.Pdf.Parsing;
   ```

Step 4: **Implement OCR Processing**: Use the following code snippet in `Program.cs` to perform OCR on a PDF document:

   ```csharp
   // Initialize the OCR processor
   using (OCRProcessor processor = new OCRProcessor())
   {
       // Load the existing PDF document
       using (FileStream stream = new FileStream("Input.pdf", FileMode.Open, FileAccess.Read))
       {    
           PdfLoadedDocument pdfLoadedDocument = new PdfLoadedDocument(stream);
           
           // Set the language for OCR processing
           processor.Settings.Language = Languages.English;   
           
           // Perform OCR on the PDF document
           processor.PerformOCR(pdfLoadedDocument);
           
           // Save the OCR-processed document
           using (FileStream outputFileStream = new FileStream("Output.pdf", FileMode.Create, FileAccess.ReadWrite))
           {
               pdfLoadedDocument.Save(outputFileStream);
           }
           
           // Close the document
           pdfLoadedDocument.Close(true);
       }    
   }
   ```

For a complete working sample, you can download the example from the [GitHub repository](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/OCR/.NET/Perform-OCR-for-the-entire-PDF-document).

To explore more features of the Syncfusion PDF library, click [here](https://www.syncfusion.com/document-processing/pdf-framework/net-core).