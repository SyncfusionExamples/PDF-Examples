# Protect PDF Files

The Syncfusion<sup>&reg;</sup> [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) provides tools for creating, reading, and editing PDF documents. It also allows you to protect your PDF files by applying encryption and setting password-based permissions.

## Steps to Protect PDF Files

Step 1: **Create a new project**: Begin by setting up a new C# Console Application project.

Step 2: **Install the NuGet package**: Add the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) package to your project from [NuGet.org](https://www.nuget.org/).

Step 3: **Include necessary namespaces**: Add these namespaces in your **Program.cs** file:

```csharp
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
```

Step 4: **Implement encryption**: Use the following code in **Program.cs** to secure your PDF file:

```csharp
//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Get the security settings of the document
    PdfSecurity security = loadedDocument.Security;
    // Set encryption to AES with a 256-bit key
    security.KeySize = PdfEncryptionKeySize.Key256Bit;
    security.Algorithm = PdfEncryptionAlgorithm.AES;
    // Set owner and user passwords for the document
    security.OwnerPassword = "owner123";
    security.UserPassword = "user123";
    // Save the secured PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
```

You can download a complete working example from [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Security/Protect-an-existing-PDF-document/).

More information about the protect PDF can be found in this [documentation](https://help.syncfusion.com/document-processing/pdf/pdf-library/net/working-with-security) section.