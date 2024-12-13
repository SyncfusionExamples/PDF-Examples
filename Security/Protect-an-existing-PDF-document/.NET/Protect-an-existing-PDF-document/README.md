# Protect PDF Files

The Syncfusion [.NET Core PDF library](https://www.syncfusion.com/document-processing/pdf-framework/net-core/pdf-library) provides tools for creating, reading, and editing PDF documents. It also allows you to protect your PDF files by applying encryption and setting password-based permissions.

## Steps to Protect PDF Files

Step 1: **Create a new project**: Begin by setting up a new C# Console Application project.

Step 2: **Install the NuGet package**: Add the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) package to your project from [NuGet.org](https://www.nuget.org/).

Step 3: **Include necessary namespaces**: Add these namespaces in your **Program.cs** file:

   ```csharp
   using Syncfusion.Pdf.Security;
   using Syncfusion.Pdf.Parsing;
   ```

Step 4: **Implement encryption**: Use the following code in **Program.cs** to secure your PDF file:

   ```csharp
   // Load the PDF document from a file stream
   using (FileStream inputFileStream = new FileStream("Input.pdf", FileMode.Open, FileAccess.Read))
   {
       // Load the PDF document
       PdfLoadedDocument document = new PdfLoadedDocument(inputFileStream);

       // Access the document's security settings
       PdfSecurity security = document.Security;

       // Set key size and encryption algorithm
       security.KeySize = PdfEncryptionKeySize.Key256Bit;
       security.Algorithm = PdfEncryptionAlgorithm.AES;

       // Specify owner and user passwords
       security.OwnerPassword = "owner123";
       security.UserPassword = "user123";

       // Save the protected PDF document to a file stream
       using (FileStream outputFileStream = new FileStream("Output.pdf", FileMode.Create))
       {
           document.Save(outputFileStream);
       }

       // Close the document
       document.Close(true);
   }
   ```

You can download a complete working example from [GitHub](https://github.com/SyncfusionExamples/PDF-Examples/tree/master/Security/Protect-an-existing-PDF-document/).

Explore more capabilities of the Syncfusion PDF library [here](https://www.syncfusion.com/document-processing/pdf-framework/net-core).