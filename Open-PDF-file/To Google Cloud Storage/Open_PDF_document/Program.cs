using Google.Cloud.Storage.V1;
using Google.Apis.Auth.OAuth2;

class Program
{
    static void Main()
    {
        // Create a byte array
        byte[] pdfBytes;
        // Load the credentials file
        GoogleCredential credential = GoogleCredential.FromFile("credentials.json");
        // Create a storage client
        StorageClient storage = StorageClient.Create(credential);
        // Download the PDF from Google Cloud Storage
        using (MemoryStream stream = new MemoryStream())
        {
            storage.DownloadObject("bucket50247", "Sample.pdf", stream);
            pdfBytes = stream.ToArray();
        }

        string filePath = "Sample.pdf";

        // Write the byte array to a PDF file
        File.WriteAllBytes(filePath, pdfBytes);
    }
}
