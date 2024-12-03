# PDF Annotations

The Syncfusion [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) is used to create, read, and edit PDF documents. This library also offers functionality to add, edit, and manage annotations in PDF files, enabling users to mark up and collaborate effectively.

## Steps to add annotation to a PDF

Step 1:  Create a new C# Console Application project.

Step 2: Install the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) NuGet package as reference to your .NET Standard applications from [NuGet.org](https://www.nuget.org/).

Step 3: Include the following namespaces in the **Program.cs** file.

```
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

```

Step 4: Include the below code snippet in **Program.cs** to add annotations to a PDF file.".
```
//Create FileStream object to read the input PDF file
using (FileStream inputFileStream = new FileStream("input.pdf", FileMode.Open, FileAccess.Read))
{
    //Load the PDF document from the input stream
    using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputFileStream))
    {
        //Get the first page of the PDF document
        PdfPageBase loadedPage = loadedDocument.Pages[0];
        //Create a new popup annotation
        PdfPopupAnnotation popupAnnotation = new PdfPopupAnnotation(new RectangleF(100, 100, 20, 20), "Comment");
        //Set the icon for the popup annotation
        popupAnnotation.Icon = PdfPopupIcon.Comment;
        //Set the color for the popup annotation
        popupAnnotation.Color = new PdfColor(Color.Yellow);
        //Add the annotation to the page
        loadedPage.Annotations.Add(popupAnnotation);
        //Save the document
        using (FileStream outpuFileStream = new FileStream("output.pdf", FileMode.Create, FileAccess.Write))
        {
            loadedDocument.Save(outpuFileStream);
        }
    }
}

```

You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Annotation/Add-a-popup-annotation-to-an-existing-PDF-document/.NET).

Click [here](https://www.syncfusion.com/document-processing/pdf-framework/net-core) to explore the rich set of Syncfusion PDF library features.