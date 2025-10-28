# PDF Forms

The Syncfusion<sup>&reg;</sup> [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) provides an easy way to create, read, and edit PDF documents. It also includes features for creating, filling, and editing PDF forms, which can include interactive form fields and form data.

## Steps to create PDF forms

Follow these steps to create a PDF form with a textbox field:

Step 1: **Create a new project**: Start by creating a new C# Console Application project.

Step 2: **Install the NuGet package**: Add the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) package to your project from [NuGet.org](https://www.nuget.org/).

Step 3: **Include necessary namespaces**: Add the following namespaces in your `Program.cs` file:

```csharp
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
```

Step 4: **Create PDF forms**: Implement the following code in `Program.cs` to add a textbox field to a PDF document:

```csharp
// Create a new PDF document
using (PdfDocument pdfDocument = new PdfDocument())
{
    // Add a new page to the PDF document
    PdfPage pdfPage = pdfDocument.Pages.Add();
    // Create a standard font
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 16);
    // Draw the title text on the page
    pdfPage.Graphics.DrawString("Job Application", font, PdfBrushes.Black, new PointF(250, 0));
    // Change the font size for form field labels
    font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
    // Draw the label "Name" on the page
    pdfPage.Graphics.DrawString("Name", font, PdfBrushes.Black, new PointF(10, 20));
    // Create a text box field for entering the name
    PdfTextBoxField nameField = new PdfTextBoxField(pdfPage, "Name");
    nameField.Bounds = new RectangleF(10, 40, 200, 20);
    nameField.ToolTip = "Name";
    // Add the field to the form
    pdfDocument.Form.Fields.Add(nameField); 
    // Draw the label "Email address" on the page
    pdfPage.Graphics.DrawString("Email address", font, PdfBrushes.Black, new PointF(10, 80));
    // Create a text box field for entering the email address
    PdfTextBoxField emailField = new PdfTextBoxField(pdfPage, "Email address");
    emailField.Bounds = new RectangleF(10, 100, 200, 20);
    emailField.ToolTip = "Email address";
    // Add the field to the form
    pdfDocument.Form.Fields.Add(emailField); 
    // Save the PDF document
    pdfDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
```

For a full working example, you can download the sample from the [GitHub repository](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Forms/Add-a-textbox-field-to-a-new-PDF-document).

More information about the forms can be found in this [documentation](https://help.syncfusion.com/document-processing/pdf/pdf-library/net/working-with-forms) section.