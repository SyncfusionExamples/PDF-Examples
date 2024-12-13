# Extract Data from PDF

The Syncfusion [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) enables the creation, reading, and editing of PDF documents. Additionally, it provides capabilities to extract data from PDFs, such as text, images, and form field values.

## Steps to Extract Data from PDF Files

Step 1: **Create a new project**: Begin by setting up a new C# Console Application project.

Step 2: **Install the NuGet package**: Add the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) package to your project from [NuGet.org](https://www.nuget.org/).

Step 3: **Include necessary namespaces**: Add these namespaces in your **Program.cs** file:

   ```csharp
   using Syncfusion.Pdf;
   using Syncfusion.Pdf.Parsing;
   using System.IO;
   ```

Step 4: **Extract data from PDF**: Use the following code in **Program.cs** to extract data from a PDF:

   ```csharp
   // Open an existing PDF document stream
   using (FileStream inputStream = new FileStream("Input.pdf", FileMode.Open, FileAccess.Read))
   {
       // Load the PDF document
       using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputStream))
       {
           string extractedText = string.Empty;

           // Extract all text from the PDF document pages
           foreach (PdfLoadedPage page in loadedDocument.Pages)
           {
               extractedText += page.ExtractText();
           }

           // Save the extracted text to a file
           File.WriteAllText("Result.txt", extractedText);
       }
   }
   ```

For a complete working example, download it from [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Text%20Extraction/Extract-text-from-the-entire-PDF-document/).

Explore more features of the Syncfusion PDF library [here](https://www.syncfusion.com/document-processing/pdf-framework/net-core).