using Dropbox.Api;

// Define the access token for authentication with the Dropbox API
var accessToken = "YOUR_ACTUAL_ACCESS_TOKEN"; // Replace with your actual access token
// Define the file path in Dropbox where the PDF file is located
var filePathInDropbox = "/path/to/save/Sample.pdf"; // Replace with the actual file path in Dropbox
// Create a new DropboxClient instance using the provided access token
using (var dbx = new DropboxClient(accessToken))
{
    // Start a download request for the specified file in Dropbox
    using (var response = await dbx.Files.DownloadAsync(filePathInDropbox))
    {
        // Get the content of the downloaded file as a stream
        var content = await response.GetContentAsStreamAsync();
        // Create a new file stream to save the downloaded content locally
        using (var fileStream = File.Create("Output.pdf"))
        {
            // Copy the content stream to the file stream
            content.CopyTo(fileStream);
            // Close the file stream once the content is copied
            fileStream.Close();
        }
    }
}
