# Converting Images to PDF

The Syncfusion [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) offers tools to create, read, and edit PDF documents. It also provides functionality to convert images into PDF files, making it easy to integrate image content into your PDF documents.

## Steps to convert images to PDF

Follow these steps to convert an image into a PDF file using the Syncfusion library:

Step 1: **Create a new project**: Start a new C# Console Application project.

Step 2: **Install the NuGet package**: Add the [Syncfusion.Pdf.Imaging.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Imaging.Net.Core) package as a reference to your project from [NuGet.org](https://www.nuget.org/).

Step 3: **Include necessary namespaces**: Add the following namespace in your `Program.cs` file:

   ```csharp
   using Syncfusion.Pdf;
   ```

Step 4: **Convert image to PDF**: Implement the following code in `Program.cs` to convert an image into a PDF file:

   ```csharp
   // Create an instance of the ImageToPdfConverter class
   var imageToPdfConverter = new ImageToPdfConverter();

   // Set the page size for the PDF
   imageToPdfConverter.PageSize = PdfPageSize.A4;

   // Set the position of the image in the PDF
   imageToPdfConverter.ImagePosition = PdfImagePosition.TopLeftCornerOfPage;

   // Create a file stream to read the image file
   using (var imageStream = new FileStream("Autumn Leaves.jpg", FileMode.Open, FileAccess.Read))
   {
       // Convert the image to a PDF document using the ImageToPdfConverter
       var pdfDocument = imageToPdfConverter.Convert(imageStream);

       // Create a file stream for the output PDF file
       using (var outputFileStream = new FileStream(Path.GetFullPath("Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
       {
           // Save the generated PDF document to the output file stream
           pdfDocument.Save(outputFileStream);
       }

       // Close the document
       pdfDocument.Close(true);
   }
   ```

You can download a complete working sample from the [GitHub repository](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Images/Convert_Image_to_PDF/.NET).

To explore more features of the Syncfusion PDF library, click [here](https://www.syncfusion.com/document-processing/pdf-framework/net-core).