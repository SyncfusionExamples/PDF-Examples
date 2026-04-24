# Recognize Form Data from PDF using C#

The Syncfusion® [Smart Form Recognizer](https://www.syncfusion.com/document-sdk/net-pdf-data-extraction) is a .NET C# library that detects form regions and extracts text fields, checkboxes, radio buttons, and signatures by interpreting visual patterns such as boxes and selection markers. The extracted results are returned as normalized JSON with confidence scores, enabling applications to automatically process form data. 

## Steps to Recognize Form Data from PDF Files

Step 1: **Create a new project:** Begin by setting up a new C# Console Application project.

Step 2:  **Install the NuGet package:** Add the [Syncfusion.SmartFormRecognizer.Net.Core](https://www.nuget.org/packages/Syncfusion.SmartFormRecognizer.Net.Core) package to your project from [NuGet.org](https://www.nuget.org/).

Step 3: **Include necessary namespaces:** Add these namespaces in your Program.cs file:

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
For a complete working example, download it from [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Data-Extraction/Smart-Form-Recognizer/Recognize-forms-using-JSON/.NET). 

More information about SmartFormRecognizer can be refer in this [documentation](https://help.syncfusion.com/document-processing/data-extraction/smart-form-recognizer/overview)section.