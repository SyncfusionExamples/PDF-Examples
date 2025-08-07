# Digital Signature with Syncfusion .NET Core PDF Library

![Digital Signature Banner](https://www.syncfusion.com/content/images/banner/digital-signature.png)

## Table of Contents
- [Video Illustration](#video-illustration)
- [Overview](#overview)
- [Steps to add a digital signature to PDF files](#steps-to-add-a-digital-signature-to-pdf-files)
  - [Step 1: Create a New Project](#step-1-create-a-new-project)
  - [Step 2: Install NuGet Package](#step-2-install-the-nuget-package)
  - [Step 3: Include Namespaces](#step-3-include-namespaces)
  - [Step 4: Add Digital Signature Code](#step-4-add-digital-signature-code)
- [GitHub Repository](#github-repository)
- [NuGet Installation](#nuget-installation)
- [Installer & License](#installer--license)

## Video Illustration

Watch this video to see how to digitally sign PDF files using Syncfusion .NET Core PDF Library:

[![Watch the video]()](https://www.youtube.com/watch?v=NNIFh1Ckdzw&t=672s)

## Overview

The Syncfusion&reg; [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) offers powerful capabilities for creating, reading, and editing PDF documents. One of its robust features is the ability to apply digital signatures to PDF files, ensuring document authenticity, integrity, and security.

## Steps to add a digital signature to PDF files

Follow these steps to digitally sign PDF files using the Syncfusion&reg; library:

### Step 1: Create a new project:

Start by creating a new C# Console Application project.

### Step 2: Install the NuGet package:

Add the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) package to your project from [NuGet.org](https://www.nuget.org/).

### Step 3: Include namespaces:

Add the following namespaces in your `Program.cs` file:

   ```csharp
   using Syncfusion.Pdf;
   using Syncfusion.Pdf.Graphics;
   using Syncfusion.Pdf.Parsing;
   using Syncfusion.Pdf.Security;
   using Syncfusion.Drawing;
   using Syncfusion.Pdf.Interactive;
   ```

### Step 4: Add digital signature code:

Use the following code snippet in `Program.cs` to add a digital signature to a PDF file:

   ```csharp
   // Open the existing PDF document as a stream
   using (FileStream inputStream = new FileStream(Path.GetFullPath("Input.pdf"), FileMode.Open, FileAccess.Read))
   {
       // Load the existing PDF document
       PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputStream);

       // Get the first page of the document
       PdfPageBase page = loadedDocument.Pages[0];

       // Load the certificate from a PFX file with a private key
       FileStream certificateStream = new FileStream(@"PDF.pfx", FileMode.Open, FileAccess.Read);
       PdfCertificate pdfCert = new PdfCertificate(certificateStream, "syncfusion");

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

       // Close the document
       loadedDocument.Close(true);
       certificateStream.Dispose();
       imageStream.Dispose();
   }
   ```
## GitHub Repository

[![GitHub](https://raw.githubusercontent.com/github/explore/main/topics/github/github.png#gh-dark-mode-only)](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Digital%20Signature/Add-a-digital-signature-to-an-existing-document/){:width="40" height="40" loading="lazy"} [Syncfusion PDF Digital Signature Example](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Digital%20Signature/Add-a-digital-signature-to-an-existing-document/)

## NuGet Installation

[![NuGet](https://img.shields.io/badge/NuGet-Package-004880?logo=nuget&logoColor=white)](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core) [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core)

## Installer & License

