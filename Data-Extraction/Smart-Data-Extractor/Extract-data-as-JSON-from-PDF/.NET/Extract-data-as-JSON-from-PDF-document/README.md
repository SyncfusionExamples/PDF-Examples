# Extract Structured Data from PDF

The Syncfusion® [Smart Data Extractor](https://www.syncfusion.com/document-sdk/net-pdf-data-extraction) is a .NET library used to extract document structures such as hierarchies, text blocks, images, headers, and footers from PDFs and scanned images by analyzing visual layout patterns like lines, boxes, and alignment. It returns structured JSON with per-field confidence scores

## Steps to Extract Structured Data from PDF Files

Step 1: **Create a new project:** Begin by setting up a new C# Console Application project.

Step 2: **Install the NuGet package:** Add the [Syncfusion.SmartDataExtractor.Net.Core](https://www.nuget.org/packages/Syncfusion.SmartDataExtractor.Net.Core) package to your project from [NuGet.org](https://www.nuget.org/).

Step 3: **Include necessary namespaces:** Add these namespaces in your Program.cs file:

```csharp
using System.IO;
using System.Text;
using Syncfusion.SmartDataExtractor;

```

Step 4: Add the following code snippet in Program.cs file to extract data from PDF.

```csharp
// Open the input PDF file as a stream.
using (FileStream stream = new FileStream(Path.GetFullPath("Input.pdf"), FileMode.Open, FileAccess.ReadWrite))
{
	// Initialize the Smart Data Extractor.
	DataExtractor extractor = new DataExtractor();
	// Extract form data as JSON.
	string data = extractor.ExtractDataAsJson(stream);
	// Save the extracted JSON data into an output file.
	File.WriteAllText(Path.GetFullPath(@"Output.json"), data, Encoding.UTF8);
}

```
For a complete working example, download it from [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Data-Extraction/Smart-Data-Extractor/Extract-data-as-JSON-from-PDF/.NET).

More information about Extract data from PDF can be refer in this [documentation](https://help.syncfusion.com/document-processing/data-extraction/smart-data-extractor/overview)section.