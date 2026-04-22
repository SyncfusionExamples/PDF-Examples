# Create Word document using C#

The Syncfusion® Smart Table Extractor is a .NET library used to extract table data from PDFs and images in Console Application.

## Steps to Extract Data from PDF in Console App

Step 1: Create a new .NET Core console application project.

Step 2: Install the [Syncfusion.SmartTableExtractor.Net.Core](https://www.nuget.org/packages/Syncfusion.SmartTableExtractor.Net.Core) NuGet package as a reference to your project from [NuGet.org](https://www.nuget.org/).

Step 3: Include the following namespaces in the Program.cs file.

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

More information about Extract Table Data from PDF can be refer in this [documentation](https://help.syncfusion.com/document-processing/data-extraction/smart-table-extractor/overview)section.