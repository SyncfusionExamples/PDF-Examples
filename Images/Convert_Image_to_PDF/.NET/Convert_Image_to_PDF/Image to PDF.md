# Image to PDF Files

The Syncfusion [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) is used to create, read, and edit PDF documents. This library also offers functionality to convert images into PDF files, allowing you to seamlessly integrate image content into PDF documents.

## Steps to convert Image to PDF files.

Step 1:  Create a new C# Console Application project.

Step 2: Install the [Syncfusion.Pdf.Imaging.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Imaging.Net.Core) NuGet package as reference to your .NET Standard applications from [NuGet.org](https://www.nuget.org/).

Step 3: Include the following namespaces in the **Program.cs** file.

```
using Syncfusion.Pdf;

```

Step 4: Include the below code snippet in **Program.cs** to convert image to PDF files.
```
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

You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Images/Convert_Image_to_PDF/.NET).

Click [here](https://www.syncfusion.com/document-processing/pdf-framework/net-core) to explore the rich set of Syncfusion PDF library features.