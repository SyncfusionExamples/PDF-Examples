using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;


// Parse the connection string to your Azure Storage Account.
CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=helloworlddocument;AccountKey=NLVp39X0fAEEsH6APP7tVgPoe7kIY/c8fjC6aS7R956iiLP6TpNw5YEDu+oDq2yrjA5oIW73iB6L+ASt+EMfEA==;EndpointSuffix=core.windows.net");
// Create a client to interact with Blob storage.
CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
// Get a reference to the container name.
CloudBlobContainer container = blobClient.GetContainerReference("helloworld");
// Get a reference to the block blob name.
CloudBlockBlob blockBlob = container.GetBlockBlobReference("sample.pdf");
// Open a file stream to save the downloaded blob content.
using (var fileStream = File.OpenWrite("sample.pdf"))
{
    // Download the blob's content to the file stream.
    blockBlob.DownloadToStream(fileStream);
}
