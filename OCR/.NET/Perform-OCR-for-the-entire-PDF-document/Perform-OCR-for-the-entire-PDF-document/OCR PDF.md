# OCR PDF Files

The Syncfusion [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) is used to create, read, and edit PDF documents. This library also offers functionality to perform OCR (Optical Character Recognition) on PDF files, enabling the extraction of text from scanned images.

## Steps to OCR PDF files.

Step 1:  Create a new C# Console Application project.

Step 2: Install the [Syncfusion.PDF.OCR.Net.Core](https://www.nuget.org/packages/Syncfusion.PDF.OCR.Net.Core) NuGet package as reference to your .NET Standard applications from [NuGet.org](https://www.nuget.org/).

Step 3: Include the following namespaces in the **Program.cs** file.

```
using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Parsing;

```

Step 4: Include the below code snippet in **Program.cs** to OCR PDF files.

```
// Initialize the OCR processor
using (OCRProcessor processor = new OCRProcessor())
{
    // Load the existing PDF document
    using (FileStream stream = new FileStream("Input.pdf", FileMode.Open, FileAccess.Read))
    {    
      PdfLoadedDocument pdfLoadedDocument = new PdfLoadedDocument(stream);
      
      // Set OCR language to process
      processor.Settings.Language = Languages.English;   
      // Process OCR by providing the PDF document
      processor.PerformOCR(pdfLoadedDocument);
      
      // Save the OCRed document
      using (FileStream outputFileStream = new FileStream(@"Output.pdf", FileMode.Create, FileAccess.ReadWrite))
      {
        //Save the PDF document to file stream.
        pdfLoadedDocument.Save(outputFileStream);
      }
      //Close the document.
      pdfLoadedDocument.Close(true);
    }    
}

```

You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/OCR/.NET/Perform-OCR-for-the-entire-PDF-document).

Click [here](https://www.syncfusion.com/document-processing/pdf-framework/net-core) to explore the rich set of Syncfusion PDF library features.