using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;


// Parse the connection string to your Azure Storage Account.
CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
// Create a client to interact with Blob storage.
CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
// Get a reference to the container name.
CloudBlobContainer container = blobClient.GetContainerReference(containerName);
// Get a reference to the block blob name.
CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
// Open a file stream to save the downloaded blob content.
using (var fileStream = File.OpenWrite("sample.pdf"))
{
    // Download the blob's content to the file stream.
    blockBlob.DownloadToStream(fileStream);
}
