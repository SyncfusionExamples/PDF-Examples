using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using File = Google.Apis.Drive.v3.Data.File;
using Syncfusion.Drawing;

PdfDocument document = new PdfDocument();
PdfPage page = document.Pages.Add();
PdfGraphics graphics = page.Graphics;
graphics.DrawString("Hello, World!", new PdfStandardFont(PdfFontFamily.Helvetica, 12), PdfBrushes.Black, new PointF(10, 10));

// Step 2: Save the PDF to a MemoryStream
MemoryStream stream = new MemoryStream();
document.Save(stream);
document.Close(true);

// Step 3: Authenticate with Google Drive
UserCredential credential;
string[] Scopes = { DriveService.Scope.Drive };
string ApplicationName = "YourAppName";

using (var stream1 = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))//Replace with your actual credentials.json
{
    string credPath = "token.json";
    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
        GoogleClientSecrets.Load(stream1).Secrets,
        Scopes,
        "user",
        CancellationToken.None,
        new FileDataStore(credPath, true)).Result;
}
// Step 4: Create Drive API service
var service = new DriveService(new BaseClientService.Initializer()
{
    HttpClientInitializer = credential,
    ApplicationName = ApplicationName,
});

// Step 5: Upload the PDF to Google Drive

var fileMetadata = new File()
{
    Name = "Sample.pdf", // Name of the file in Google Drive
    MimeType = "application/pdf",
};
FilesResource.CreateMediaUpload request;
using (var fs = new MemoryStream(stream.ToArray()))
{
    request = service.Files.Create(fileMetadata, fs, "application/pdf");
    request.Upload();
}

File file = request.ResponseBody;

Console.WriteLine("File ID: " + file.Id);
