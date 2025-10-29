# Converting Images to PDF

The Syncfusion<sup>&reg;</sup> [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) offers tools to create, read, and edit PDF documents. It also provides functionality to convert images into PDF files, making it easy to integrate image content into your PDF documents.

## Steps to convert images to PDF

Follow these steps to convert an image into a PDF file using the Syncfusion<sup>&reg;</sup> library:

Step 1: **Create a new project**: Start a new C# Console Application project.

Step 2: **Install the NuGet package**: Add the [Syncfusion.Pdf.Imaging.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Imaging.Net.Core) package as a reference to your project from [NuGet.org](https://www.nuget.org/).

Step 3: **Include necessary namespaces**: Add the following namespace in your `Program.cs` file:

```csharp
using Syncfusion.Pdf;
```

Step 4: **Convert image to PDF**: Implement the following code in `Program.cs` to convert an image into a PDF file:

```csharp
// Create an instance of the ImageToPdfConverter class 
ImageToPdfConverter imageToPdfConverter = new ImageToPdfConverter();
// Set the page size for the document
imageToPdfConverter.PageSize = PdfPageSize.A4;
// Set the position of the image in the document
imageToPdfConverter.ImagePosition = PdfImagePosition.TopLeftCornerOfPage;
// Create a file stream to read the image file 
using (FileStream imageStream = new FileStream(Path.GetFullPath(@"Data/Autumn Leaves.jpg"), FileMode.Open, FileAccess.Read))
// Convert the image to a PDF document using the ImageToPdfConverter 
using (PdfDocument pdfDocument = imageToPdfConverter.Convert(imageStream))
{
    //Save the PDF document
    pdfDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
```

You can download a complete working sample from the [GitHub repository](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Images/Convert_Image_to_PDF/.NET).

More information about the Image to PDF conversion can be found in this [documentation](https://help.syncfusion.com/document-processing/pdf/pdf-library/net/converting-images-to-pdf) section.