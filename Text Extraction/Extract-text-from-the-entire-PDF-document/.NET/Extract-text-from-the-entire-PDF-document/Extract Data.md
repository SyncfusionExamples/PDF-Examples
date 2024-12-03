# Extract Data from PDF

The Syncfusion [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) is used to create, read, and edit PDF documents. This library also offers functionality to extract data from PDF files, including text, images, and form field values.

## Steps to extract data from PDF files.

Step 1:  Create a new C# Console Application project.

Step 2: Install the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) NuGet package as reference to your .NET Standard applications from [NuGet.org](https://www.nuget.org/).

Step 3: Include the following namespaces in the **Program.cs** file.

```
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System.IO;

```

Step 4: Include the below code snippet in **Program.cs** to extract data from PDF files.

```
// Open existing PDF document stream.
using (FileStream inputStream = new FileStream("Input.pdf", FileMode.Open, FileAccess.Read))
{
    // Load the PDF document.
    using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputStream))
    {
        string extractedText = string.Empty;
        
        // Extract all text from PDF document pages.
        foreach (PdfLoadedPage page in loadedDocument.Pages)
        {
            extractedText += page.ExtractText();
        }
        
        // Save extracted text to file.
        File.WriteAllText("Result.txt", extractedText);
    }
}

```

You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Text%20Extraction/Extract-text-from-the-entire-PDF-document/).

Click [here](https://www.syncfusion.com/document-processing/pdf-framework/net-core) to explore the rich set of Syncfusion PDF library features.