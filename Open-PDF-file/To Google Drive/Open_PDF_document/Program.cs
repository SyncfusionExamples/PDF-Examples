
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;


UserCredential credential;
string[] Scopes = { DriveService.Scope.DriveReadonly };
string ApplicationName = "YourAppName";

using (var stream1 = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
{
    string credPath = "token.json";
    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
        GoogleClientSecrets.Load(stream1).Secrets,
        Scopes,
        "user",
        CancellationToken.None,
        new FileDataStore(credPath, true)).Result;
}

// Step 2: Create Drive API service
var service = new DriveService(new BaseClientService.Initializer()
{
    HttpClientInitializer = credential,
    ApplicationName = ApplicationName,
});

// Step 3: Specify the file ID of the PDF you want to open
string fileId = "YOUR_FILE_ID"; // Replace with the actual file ID YOUR_FILE_ID

// Step 4: Download the PDF file from Google Drive
var request = service.Files.Get(fileId);
var stream = new MemoryStream();
request.Download(stream);

// Step 5: Save the PDF locally
using (FileStream fileStream = new FileStream("output.pdf", FileMode.Create, FileAccess.Write))
{
    stream.WriteTo(fileStream);
}

