# Digital Signature

The Syncfusion [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) enables users to create, read, and edit PDF documents effortlessly. In addition to these features, the library provides robust functionality for applying digital signatures to PDF files, ensuring document authenticity, integrity, and security.

## Steps to Add a Digital Signature to PDF Files

Step 1:  Create a new C# Console Application project.

Step 2: Install the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) NuGet package as reference to your .NET Standard applications from [NuGet.org](https://www.nuget.org/).

Step 3: Include the following namespaces in the **Program.cs** file.


```
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using Syncfusion.Drawing;

```

Step 4: Include the below code snippet in **Program.cs** to add a digital signature to PDF files.
```
//Open existing PDF document as stream
using (FileStream inputStream = new FileStream(Path.GetFullPath("Input.pdf"), FileMode.Open, FileAccess.Read))
{
    // Load the existing PDF document
    PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputStream);

    // Gets the first page of the document
    PdfPageBase page = loadedDocument.Pages[0];

    // Load the certificate from a PFX file with a private key
    FileStream certificateStream = new FileStream(@"PDF.pfx", FileMode.Open, FileAccess.Read);
    PdfCertificate pdfCert = new PdfCertificate(certificateStream, "password123");

    // Create a signature
    PdfSignature signature = new PdfSignature(loadedDocument, page, pdfCert, "Signature");

    // Set signature information
    signature.Bounds = new RectangleF(new PointF(0, 0), new SizeF(200, 100));
    signature.ContactInfo = "johndoe@owned.us";
    signature.LocationInfo = "Honolulu, Hawaii";
    signature.Reason = "I am the author of this document.";

    // Load the image for the signature field
    FileStream imageStream = new FileStream("signature.png", FileMode.Open, FileAccess.Read);
    PdfBitmap signatureImage = new PdfBitmap(imageStream);

    // Draw the image on the signature field
    signature.Appearance.Normal.Graphics.DrawImage(signatureImage, new RectangleF(0, 0, signature.Bounds.Width, signature.Bounds.Height));

    // Save the document to a file stream
    using (FileStream outputFileStream = new FileStream("signed.pdf", FileMode.Create, FileAccess.ReadWrite))
    {
        loadedDocument.Save(outputFileStream);
    }

    //Close the document.
    loadedDocument.Close(true);
}

```

You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Digital%20Signature/Add-a-digital-signature-to-an-existing-document/).

Click [here](https://www.syncfusion.com/document-processing/pdf-framework/net-core) to explore the rich set of Syncfusion PDF library features.