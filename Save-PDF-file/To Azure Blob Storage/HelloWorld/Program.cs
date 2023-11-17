using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

// Create a new PDF document
using (PdfDocument doc = new PdfDocument())
{
    // Add a page to the document
    PdfPage page = doc.Pages.Add();
    // Get the graphics object for drawing on the page
    PdfGraphics graphics = page.Graphics;
    // Create a font to use for drawing text
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
    // Draw the text
    graphics.DrawString("Hello, World!", font, PdfBrushes.Black, new PointF(10, 10));
    // Create a memory stream to save the PDF document
    MemoryStream stream = new MemoryStream();
    doc.Save(stream);
    // Write the contents of the memory stream to a file named "sample.pdf"
    File.WriteAllBytes("sample.pdf", stream.ToArray());
    // Close the document
    doc.Close(true);
}
// Parse the connection string for the Azure Storage Account
CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
// Create a client for accessing Blob storage
CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
// Get a reference to the container named "helloworld"
CloudBlobContainer container = blobClient.GetContainerReference(containerName);
container.CreateIfNotExists();
// Get a reference to the block blob named "sample.pdf"
CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
// Open the local file "sample.pdf" for reading
using (var fileStream = File.OpenRead("sample.pdf"))
{
    // Upload the contents of the local file to the Azure Blob Storage
    blockBlob.UploadFromStream(fileStream);
}
