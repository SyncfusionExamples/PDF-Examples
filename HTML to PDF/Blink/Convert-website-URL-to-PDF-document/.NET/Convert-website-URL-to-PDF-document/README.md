# HTML to PDF Conversion

The Syncfusion [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) allows you to create, read, and edit PDF documents. It also includes functionality for accurately converting HTML content into PDF files.

## Steps to convert HTML to PDF

Follow these steps to convert HTML content into a PDF file using the Syncfusion library:

Step 1: **Create a new project**: Initialize a new C# Console Application project.

Step 2: **Install the NuGet package**: Add the [Syncfusion.HtmlToPdfConverter.Net.Windows](https://www.nuget.org/packages/Syncfusion.HtmlToPdfConverter.Net.Windows) package as a reference in your .NET Standard application from [NuGet.org](https://www.nuget.org/).

Step 3: **Include necessary namespaces**: Add the following namespaces in your `Program.cs` file:

   ```csharp
   using Syncfusion.HtmlConverter;
   using Syncfusion.Pdf;
   using System.Runtime.InteropServices;
   ```

Step 4: **Convert HTML to PDF**: Implement the following code in `Program.cs` to convert a website URL to a PDF file:

   ```csharp
   // Initialize the HTML to PDF converter
   HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
   
   // Convert a URL to a PDF document
   PdfDocument document = htmlConverter.Convert("https://www.syncfusion.com");
   
   // Create the FileStream to save the PDF document
   FileStream fileStream = new FileStream("HTML-to-PDF.pdf", FileMode.CreateNew, FileAccess.ReadWrite);
   
   // Save and close the PDF document
   document.Save(fileStream);
   document.Close(true);
   ```

You can download a complete working sample from the [GitHub repository](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/HTML%20to%20PDF/Blink/Convert-website-URL-to-PDF-document).

To explore more features of the Syncfusion PDF library, click [here](https://www.syncfusion.com/document-processing/pdf-framework/net-core).