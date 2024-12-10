# Redaction PDF Files

The Syncfusion [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) enables users to create, read, and edit PDF documents effortlessly. In addition to these features, the library provides functionality for redacting PDF content, allowing users to permanently remove or hide sensitive information while preserving the integrity of the rest of the document.

## Steps to redaction PDF files.

Step 1:  Create a new C# Console Application project.

Step 2: Install the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) NuGet package as reference to your .NET Standard applications from [NuGet.org](https://www.nuget.org/).

Step 3: Include the following namespaces in the **Program.cs** file.

```
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

```

Step 4: Include the below code snippet in **Program.cs** to redaction PDF files.
```
using (FileStream docStream = new FileStream(@"Input.pdf", FileMode.Open, FileAccess.Read))
{
    //Load the PDF document from the input stream
    using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream))
    {
        // Get the first page of the loaded document
        PdfLoadedPage firstPage = loadedDocument.Pages[0] as PdfLoadedPage;
        // Create a PDF redaction for the specified rectangle on the page
        RectangleF redactionRectangle = new RectangleF(340, 120, 140, 20);
        PdfRedaction redaction = new PdfRedaction(redactionRectangle);
        // Add the redaction to the first page
        firstPage.AddRedaction(redaction);
        //Redact the contents from the PDF document
        loadedDocument.Redact();
        
        // Save the redacted PDF document to a file stream
        using (FileStream outputFileStream = new FileStream("Redact.pdf", FileMode.Create, FileAccess.ReadWrite))
        {
            loadedDocument.Save(outputFileStream);
        }
    }
}

```

You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Redaction/Removing-sensitive-content-from-the-PDF-document/).

Click [here](https://www.syncfusion.com/document-processing/pdf-framework/net-core) to explore the rich set of Syncfusion PDF library features.