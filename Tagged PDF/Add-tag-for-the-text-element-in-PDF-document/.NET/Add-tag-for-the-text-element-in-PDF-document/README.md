# Accessible PDF Files

The Syncfusion<sup>&reg;</sup> [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) facilitates the creation, reading, and editing of PDF documents. It also offers features for generating accessible PDFs that adhere to accessibility standards, making content accessible to individuals with disabilities.

## Steps to Create Accessible PDF Files

Step 1: **Create a new project**: Start by setting up a new C# Console Application project.

Step 2: **Install the NuGet package**: Add the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) package to your project from [NuGet.org](https://www.nuget.org/).

Step 3: **Include necessary namespaces**: Add these namespaces in your **Program.cs** file:

```csharp
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
```

Step 4: **Implement accessibility**: Use the following code in **Program.cs** to create an accessible PDF:

```csharp
// Create new PDF document
using (PdfDocument document = new PdfDocument())
{
    // Set the document title
    document.DocumentInformation.Title = "Accessible PDF document";
    // Create a new page
    PdfPage page = document.Pages.Add();
    // Initialize the structure element with tag type paragraph
    PdfStructureElement paragraphStructure = new PdfStructureElement(PdfTagType.Paragraph);
    // Sets the actual text content
    paragraphStructure.ActualText = "Simple paragraph element";
    // Defines the text content for the paragraph
    string paragraphText = "Adventure Works Cycles, the fictitious company on which the AdventureWorks sample databases are based, is a large, multinational manufacturing company. The company manufactures and sells metal and composite bicycles to North American, European, and Asian commercial markets. While its base operation is located in Washington with 290 employees, several regional sales teams are located throughout their market base.";
    // Initialize the PDF text element with the paragraph content
    PdfTextElement textElement = new PdfTextElement(paragraphText);
    // Assign the tag to the text element
    textElement.PdfTag = paragraphStructure;
    // Set the font for the text element
    textElement.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
    // Set the brush color for the text element
    textElement.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));
    // Draw the text element on the PDF page
    textElement.Draw(page, new RectangleF(0, 0, page.Graphics.ClientSize.Width, 200));
    // Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
```

You can download a complete working example from [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Tagged%20PDF/Add-tag-for-the-text-element-in-PDF-document).

More information about the accessible PDF can be found in this [documentation](https://help.syncfusion.com/document-processing/pdf/pdf-library/net/working-with-tagged-pdf) section.