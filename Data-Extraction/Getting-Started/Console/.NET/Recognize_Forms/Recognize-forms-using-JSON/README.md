# Create Word document using C#

The Syncfusion® Smart Form Recognizer is a .NET C# library that detects and extracts structured form data from PDFs and images in Console Application.

## Steps to Extract Data from PDF in Console App

Step 1: Create a new .NET Core console application project.

Step 2: Install the [Syncfusion.SmartFormRecognizer.Net.Core](https://www.nuget.org/packages/Syncfusion.SmartFormRecognizer.Net.Core) NuGet package as a reference to your project from [NuGet.org](https://www.nuget.org/).

Step 3: Include the following namespaces in the Program.cs file.

```csharp
using System.IO;
using Syncfusion.SmartFormRecognizer;
```

Step 4: Add the following code snippet in Program.cs file to extract data from PDF.

```csharp
// Read the input PDF file as stream.
using (FileStream inputStream = new FileStream(Path.GetFullPath(@"Input.pdf"), FileMode.Open, FileAccess.ReadWrite))
{
	// Initialize the Form Recognizer.
	FormRecognizer smartFormRecognizer = new FormRecognizer();
	// Recognize the form and get the output as JSON string.
	string outputJson = smartFormRecognizer.RecognizeFormAsJson(inputStream);
	// Save the output JSON to file.
	File.WriteAllText(Path.GetFullPath(@"Output.json"),outputJson);
}
```

More information about SmartFormRecognizer can be refer in this [documentation](https://help.syncfusion.com/document-processing/data-extraction/smart-form-recognizer/overview)section.