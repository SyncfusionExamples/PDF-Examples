using System;
using Syncfusion.Pdf;
using Google.Cloud.Storage.V1;
using Syncfusion.Pdf.Graphics;
using Google.Apis.Auth.OAuth2;
using Syncfusion.Drawing;
using System.Security.AccessControl;

class Program
{
    static void Main()
    {
        // Step 1: Create a PDF document
        PdfDocument document = new PdfDocument();

        // Step 2: Add a page
        PdfPage page = document.Pages.Add();

        // Step 3: Add content to the page (e.g., text, images, etc.)
        PdfGraphics graphics = page.Graphics;
        graphics.DrawString("Hello, World!", new PdfStandardFont(PdfFontFamily.Helvetica, 12), PdfBrushes.Black, new PointF(10, 10));

        // Step 4: Save the PDF to a memory stream
        MemoryStream stream = new MemoryStream();
        document.Save(stream);
        document.Close(true);

        // Step 5: Upload the PDF to Google Cloud Storage
        // Load the credentials file
        GoogleCredential credential = GoogleCredential.FromFile("credentials.json");

        // Create a storage client
        StorageClient storage = StorageClient.Create(credential);

        // Upload the PDF to the specified bucket and object name
        storage.UploadObject("bucket50247", "Sample.pdf", null, stream);

    }
}