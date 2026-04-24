#  Extract Structured Table Data from PDF using C#

The Syncfusion® [Smart Table Extractor](https://www.syncfusion.com/document-sdk/net-pdf-data-extraction) is a .NET library used to extract table data from PDFs and images.

## Steps to Structured Table Data from PDF Files

Step 1: **Create a new project:** Begin by setting up a new C# Console Application project.

Step 2: **Install the NuGet package:** Add the [Syncfusion.SmartTableExtractor.Net.Core](https://www.nuget.org/packages/Syncfusion.SmartTableExtractor.Net.Core) package to your project from [NuGet.org](https://www.nuget.org/).

Step 3: **Include necessary namespaces:** Add these namespaces in your Program.cs file:
```csharp
using System.IO;
using System.Text;
using Syncfusion.SmartTableExtractor;
```

Step 4: Add the following code snippet in Program.cs file to extract data from PDF.

```csharp
// Open the input PDF file as a stream.
using (FileStream stream = new FileStream(Path.GetFullPath(@"Input.pdf"), FileMode.Open, FileAccess.ReadWrite))
{
	// Initialize the Smart Table Extractor.
	TableExtractor extractor = new TableExtractor();
	// Extract table data from the PDF document as JSON string.
	string data = extractor.ExtractTableAsJson(stream);
	// Save the extracted JSON data into an output file.
	File.WriteAllText(Path.GetFullPath(@"Output.json"), data, Encoding.UTF8);
}
```
For a complete working example, download it from [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Data-Extraction/Smart-Table-Extractor/Extract-tables-from-pdf-document/.NET). 

More information about Extract Table Data from PDF can be refer in this [documentation](https://help.syncfusion.com/document-processing/data-extraction/smart-table-extractor/overview)section.