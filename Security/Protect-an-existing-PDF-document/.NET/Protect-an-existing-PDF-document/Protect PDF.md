# Protect PDF Files

The Syncfusion [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) is used to create, read, and edit PDF documents. This library also offers functionality to protect PDF files by applying encryption and setting password-based permissions.

## Steps to protect PDF files.

Step 1:  Create a new C# Console Application project.

Step 2: Install the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) NuGet package as reference to your .NET Standard applications from [NuGet.org](https://www.nuget.org/).

Step 3: Include the following namespaces in the **Program.cs** file.


```
using Syncfusion.Pdf.Security;
using Syncfusion.Pdf.Parsing;

```

Step 4: Include the below code snippet in **Program.cs** to protect PDF files.
```
// Load the PDF document from a file stream
using (FileStream inputFileStream = new FileStream("Input.pdf", FileMode.Open, FileAccess.Read))
{
    // Load the PDF document
    PdfLoadedDocument document = new PdfLoadedDocument(inputFileStream);

    //  Gets a security object for the document
    PdfSecurity security = document.Security;
    // Configure key size and encryption algorithm
    security.KeySize = PdfEncryptionKeySize.Key256Bit;
    security.Algorithm = PdfEncryptionAlgorithm.AES;
    // Assign owner and user passwords
    security.OwnerPassword = "owner123";
    security.UserPassword = "user123";

    // Save the PDF document in to a file stream
    using (FileStream outputFileStream = new FileStream("Output.pdf", FileMode.Create))
    {
        document.Save(outputFileStream);
    }

    // Close the document
    document.Close(true);
}

```

You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Security/Protect-an-existing-PDF-document/).

Click [here](https://www.syncfusion.com/document-processing/pdf-framework/net-core) to explore the rich set of Syncfusion PDF library features.