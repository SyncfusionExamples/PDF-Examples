# PDF Annotations

The Syncfusion [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) provides powerful tools to create, read, and edit PDF documents. This library also includes features to add, edit, and manage annotations in PDF files, enabling effective markup and collaboration.

## Steps to add annotations to a PDF

Follow these steps to add a popup annotation to a PDF file using the Syncfusion library:

Step 1. **Create a new project**: Set up a new C# Console Application project.

Step 2. **Install NuGet package**: Add the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) package to your .NET Standard application from [NuGet.org](https://www.nuget.org/).

Step 3. **Include necessary namespaces**: Add the following namespaces to your `Program.cs` file:

   ```csharp
   using Syncfusion.Drawing;
   using Syncfusion.Pdf;
   using Syncfusion.Pdf.Graphics;
   using Syncfusion.Pdf.Interactive;
   using Syncfusion.Pdf.Parsing;
   ```

Step 4. **Code to add annotations**: Use the following code snippet in `Program.cs` to insert annotations into a PDF file:

   ```csharp
   // Create a FileStream object to read the input PDF file
   using (FileStream inputFileStream = new FileStream("input.pdf", FileMode.Open, FileAccess.Read))
   {
       // Load the PDF document from the input stream
       using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputFileStream))
       {
           // Access the first page of the PDF document
           PdfPageBase loadedPage = loadedDocument.Pages[0];
           
           // Create a new popup annotation
           PdfPopupAnnotation popupAnnotation = new PdfPopupAnnotation(new RectangleF(100, 100, 20, 20), "Comment");          
           // Set the icon for the popup annotation
           popupAnnotation.Icon = PdfPopupIcon.Comment;       
           // Set the color for the popup annotation
           popupAnnotation.Color = new PdfColor(Color.Yellow);     
           // Add the annotation to the page
           loadedPage.Annotations.Add(popupAnnotation);
           
           // Save the updated document
           using (FileStream outputFileStream = new FileStream("output.pdf", FileMode.Create, FileAccess.Write))
           {
               loadedDocument.Save(outputFileStream);
           }
       }
   }
   ```

For a complete working example, visit the [GitHub repository](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Annotation/Add-a-popup-annotation-to-an-existing-PDF-document/.NET).

To learn more about the extensive features of the Syncfusion PDF library, click [here](https://www.syncfusion.com/document-processing/pdf-framework/net-core).