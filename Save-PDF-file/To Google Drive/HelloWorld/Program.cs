using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using File = Google.Apis.Drive.v3.Data.File;
using Syncfusion.Drawing;

// Create a new PDF document
PdfDocument document = new PdfDocument();
// Add a new page to the document
PdfPage page = document.Pages.Add();
// Get graphics object for the page
PdfGraphics graphics = page.Graphics;
// Draw text on the page
graphics.DrawString("Hello, World!", new PdfStandardFont(PdfFontFamily.Helvetica, 12), PdfBrushes.Black, new PointF(10, 10));
// Create a memory stream to save the PDF document
MemoryStream stream = new MemoryStream();
// Save the document to the memory stream
document.Save(stream);
// Close the document
document.Close(true);

// Load Google Drive API credentials from a file
UserCredential credential;
string[] Scopes = { DriveService.Scope.Drive };
string ApplicationName = "YourAppName";

using (var stream1 = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))//Replace with your actual credentials.json
{
    string credPath = "token.json";
    // Authorize the Google Drive API access
    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
        GoogleClientSecrets.Load(stream1).Secrets,
        Scopes,
        "user",
        CancellationToken.None,
        new FileDataStore(credPath, true)).Result;
}
// Create a new instance of Google Drive service
var service = new DriveService(new BaseClientService.Initializer()
{
    HttpClientInitializer = credential,
    ApplicationName = ApplicationName,
});


// Create metadata for the file to be uploaded
var fileMetadata = new File()
{
    Name = "Sample1.pdf", // Name of the file in Google Drive
    MimeType = "application/pdf",
};
FilesResource.CreateMediaUpload request;

// Create a memory stream from the PDF document
using (var fs = new MemoryStream(stream.ToArray()))
{
    // Create an upload request for Google Drive
    request = service.Files.Create(fileMetadata, fs, "application/pdf");
    // Upload the file
    request.Upload();
}


