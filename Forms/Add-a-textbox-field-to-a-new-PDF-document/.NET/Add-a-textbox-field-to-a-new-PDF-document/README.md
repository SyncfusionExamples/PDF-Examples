# PDF Forms

The Syncfusion [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) is used to create, read, and edit PDF documents. This library also offers functionality for creating, filling, and editing PDF forms, such as interactive form fields and form data.

## Steps to Create PDF Forms

Step 1:  Create a new C# Console Application project.

Step 2: Install the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) NuGet package as reference to your .NET Standard applications from [NuGet.org](https://www.nuget.org/).

Step 3: Include the following namespaces in the **Program.cs** file.


```
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

```

Step 4: Include the below code snippet in **Program.cs** to create PDF forms.
```
// Create a new PDF document
using (PdfDocument pdfDocument = new PdfDocument())
{
    // Add a new page to the PDF document
    PdfPage pdfPage = pdfDocument.Pages.Add();

    // Set the standard font
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 16);

    // Draw the string "Job Application"
    pdfPage.Graphics.DrawString("Job Application", font, PdfBrushes.Black, new PointF(250, 0));

    // Change the font size for the form fields
    font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);

    // Draw the string "Name"
    pdfPage.Graphics.DrawString("Name", font, PdfBrushes.Black, new PointF(10, 20));

    // Create a text box field for name
    PdfTextBoxField nameField = new PdfTextBoxField(pdfPage, "Name");
    nameField.Bounds = new RectangleF(10, 40, 200, 20);
    nameField.ToolTip = "Name";
    pdfDocument.Form.Fields.Add(nameField);

    // Draw the string "Email address"
    pdfPage.Graphics.DrawString("Email address", font, PdfBrushes.Black, new PointF(10, 80));

    // Create a text box field for email address
    PdfTextBoxField emailField = new PdfTextBoxField(pdfPage, "Email address");
    emailField.Bounds = new RectangleF(10, 100, 200, 20);
    emailField.ToolTip = "Email address";
    pdfDocument.Form.Fields.Add(emailField);

    // Save the PDF document in to a file stream
    using (FileStream outputFileSteam = new FileStream("Output.pdf", FileMode.Create))
    {
        pdfDocument.Save(outputFileSteam);
    }
}

```

You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Forms/Add-a-textbox-field-to-a-new-PDF-document).

Click [here](https://www.syncfusion.com/document-processing/pdf-framework/net-core) to explore the rich set of Syncfusion PDF library features.