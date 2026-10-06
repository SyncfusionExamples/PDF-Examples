# Convert PDF to Word

The Syncfusion® [Smart Data Extractor](https://www.syncfusion.com/document-sdk/net-pdf-data-extraction) is a .NET library used to extract document structures such as hierarchies, text blocks, images, headers, and footers from PDFs and scanned images by analyzing visual layout patterns like lines, boxes, and alignment. It converts the extracted content into a Word document for easy editing, formatting, and sharing.

## Steps to Convert PDF to Word

Step 1: **Create a new project:** Begin by setting up a new C# Console Application project.

Step 2: **Install the NuGet package:** Add the [Syncfusion.SmartDataExtractor.Net.Core](https://www.nuget.org/packages/Syncfusion.SmartDataExtractor.Net.Core) package to your project from [NuGet.org](https://www.nuget.org/).

Step 3: **Include necessary namespaces:** Add these namespaces in your Program.cs file:

```csharp
using Syncfusion.DocIO.DLS;
using Syncfusion.SmartDataExtractor;

```

Step 4: Add the following code snippet in Program.cs file to extract data from PDF.

```csharp
//Open the input PDF file as a stream.

using (FileStream stream = new FileStream("Input.pdf", FileMode.Open, FileAccess.Read))
{

    //Initialize the Data Extractor.
	DataExtractor extractor = new DataExtractor();
    //Extract data as WordDocument.
	WordDocument document = extractor.ExtractDataAsWordDocument(stream);
    using MemoryStream saveStream = new MemoryStream();
    //Save the extracted Word data into an output file.
	document.Save(saveStream, FormatType.Docx);
    document.Close();
}
```
For a complete working example, download it from [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Data-Extraction/Smart-Data-Extractor/Convert-data-as-Word-from-PDF/.NET).

More information about Extract data from PDF can be refer in this [documentation](https://help.syncfusion.com/document-processing/data-extraction/net/conversions/pdf-to-word#convert-pdf-or-image-to-word-document) section.