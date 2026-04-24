# Extract Structured Data from PDF as Markdown

The Syncfusion® [Smart Data Extractor](https://www.syncfusion.com/document-sdk/net-pdf-data-extraction) is a .NET library that extracts document structures such as hierarchies, text blocks, images, headers, and footers from PDFs and scanned images by analyzing visual layout patterns like lines, boxes, and alignment.

## Steps to Extract Data as Markdown from PDF Files

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
//Open the input PDF file as a stream.
using (FileStream stream = new FileStream("Input.pdf", FileMode.Open, FileAccess.Read))
{
    //Initialize the Smart Data Extractor.
    DataExtractor extractor = new DataExtractor();
    //Extract data as Markdown.
    string data = extractor.ExtractDataAsMarkdown(stream);
    //Save the extracted Markdown data into an output file.
    File.WriteAllText("Output.md", data, Encoding.UTF8);
}

```
More information about Extract data from PDF can be refer in this [documentation](https://help.syncfusion.com/document-processing/data-extraction/smart-data-extractor/overview)section.