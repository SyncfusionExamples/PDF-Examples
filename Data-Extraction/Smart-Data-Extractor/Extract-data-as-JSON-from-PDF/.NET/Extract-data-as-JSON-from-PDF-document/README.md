# Create Word document using C#

The Syncfusion® Smart Data Extractor is a .NET library used to extract structured data and document elements from PDFs and images in Console Application.

## Steps to Extract Data from PDF in Console App

Step 1: Create a new .NET Core console application project.

Step 2: Install the [Syncfusion.SmartDataExtractor.Net.Core](https://www.nuget.org/packages/Syncfusion.SmartDataExtractor.Net.Core) NuGet package as a reference to your project from [NuGet.org](https://www.nuget.org/).

Step 3: Include the following namespaces in the Program.cs file.

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

More information about Extract data from PDF can be refer in this [documentation](https://help.syncfusion.com/document-processing/data-extraction/smart-data-extractor/overview)section.