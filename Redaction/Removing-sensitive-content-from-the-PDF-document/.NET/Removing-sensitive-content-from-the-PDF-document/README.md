# Redacting PDF Files

The Syncfusion&reg; [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) allows users to create, read, and edit PDFs seamlessly. One of its key features is the ability to redact PDF content, enabling the permanent removal or hiding of sensitive information while maintaining the rest of the document's integrity.

## Steps to Redact PDF Files

Step 1: **Create a new project**: Start by creating a new C# Console Application project.

Step 2: **Install the NuGet package**: Add the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) package to your project via [NuGet.org](https://www.nuget.org/).

Step 3: **Include necessary namespaces**: Add these namespaces to your **Program.cs** file:

   ```csharp
   using Syncfusion.Pdf.Parsing;
   using Syncfusion.Pdf.Redaction;
   using Syncfusion.Pdf;
   using Syncfusion.Drawing;
   ```

Step 4: **Implement redaction**: Use the following code in **Program.cs** to perform PDF redaction:

   ```csharp
   using (FileStream docStream = new FileStream(@"Input.pdf", FileMode.Open, FileAccess.Read))
   {
       // Load the PDF document from the input stream
       using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream))
       {
           // Access the first page of the document
           PdfLoadedPage firstPage = loadedDocument.Pages[0] as PdfLoadedPage;

           // Define a redaction area
           RectangleF redactionRectangle = new RectangleF(340, 120, 140, 20);
           PdfRedaction redaction = new PdfRedaction(redactionRectangle);

           // Apply the redaction to the page
           firstPage.AddRedaction(redaction);

           // Execute the redaction
           loadedDocument.Redact();

           // Save the redacted document
           using (FileStream outputFileStream = new FileStream("Redact.pdf", FileMode.Create, FileAccess.ReadWrite))
           {
               loadedDocument.Save(outputFileStream);
           }
       }
   }
   ```

You can download a complete working example from [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Redaction/Removing-sensitive-content-from-the-PDF-document/).

More information about the redacting PDF can be found in this [documentation](https://help.syncfusion.com/document-processing/pdf/pdf-library/net/working-with-redaction) section.