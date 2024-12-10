# Split PDF Files

The Syncfusion [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) is used to create, read, and edit PDF documents. This library also provides functionality for splitting PDF files into multiple documents

## Steps to split PDF files.

Step 1:  Create a new C# Console Application project.

Step 2: Install the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) NuGet package as reference to your .NET Standard applications from [NuGet.org](https://www.nuget.org/).

Step 3: Include the following namespaces in the **Program.cs** file.


```
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf

```

Step 4: Include the below code snippet in **Program.cs** to split PDF files.
```
// Create the FileStream object to read the input PDF file
using (FileStream inputFileStream = new FileStream("Input.pdf", FileMode.Open, FileAccess.Read))
{
    // Load the PDF document from the input stream
    using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputFileStream)) 
    {
        // Iterate over the pages of the loaded document
        for (int pageIndex = 0; pageIndex < loadedDocument.PageCount; pageIndex++) 
        {
            // Create a new PdfDocument object to hold the output
            using (PdfDocument outputDocument = new PdfDocument())   
            {
                // Import the page from the loadedDocument to the outputDocument
                outputDocument.ImportPage(loadedDocument, pageIndex); 
                
                // Create the FileStream object to write the output PDF file
                using (FileStream outputFileStream = new FileStream($"Output{pageIndex}.pdf", FileMode.Create, FileAccess.Write))
                {
                    // Save the outputDocument into the outputFileStream
                    outputDocument.Save(outputFileStream);
                }
            }
        }
    }
}

```

You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Pages/Splitting-PDF-file-into-individual-pages/).

Click [here](https://www.syncfusion.com/document-processing/pdf-framework/net-core) to explore the rich set of Syncfusion PDF library features.