using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Dropbox.Api;
using Dropbox.Api.Files;
using Syncfusion.Drawing;


PdfDocument doc = new PdfDocument();
PdfPage page = doc.Pages.Add();

PdfGraphics graphics = page.Graphics;
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);

graphics.DrawString("Hello, World!", font, PdfBrushes.Black, new PointF(10, 10));

// Add more content if needed...

// Save the PDF to a memory stream.
MemoryStream stream = new MemoryStream();
doc.Save(stream);
doc.Close(true);

var accessToken = "YOUR_ACCESS_TOKEN";// Replace with your actual access token

using (var dbx = new DropboxClient(accessToken))
{
    var uploadResult = await dbx.Files.UploadAsync(
        "/path/to/save/yourfile.pdf",
        WriteMode.Overwrite.Instance,
        body: new MemoryStream(stream.ToArray()));

    Console.WriteLine("Saved to Dropbox as " + uploadResult.PathDisplay);
}

