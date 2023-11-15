using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Dropbox.Api;
using Dropbox.Api.Files;
using Syncfusion.Drawing;

// Create a new PDF document.
PdfDocument doc = new PdfDocument();
// Add a new page to the document.
PdfPage page = doc.Pages.Add();
// Get the graphics object for the page to draw on.
PdfGraphics graphics = page.Graphics;
// Create a font for drawing text.
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
// Draw the text 
graphics.DrawString("Hello, World!", font, PdfBrushes.Black, new PointF(10, 10));
// Save the PDF to a memory stream.
MemoryStream stream = new MemoryStream();
doc.Save(stream);
// Close the PDF document.
doc.Close(true);
var accessToken = "sl.BoKwHL9XbylXxxpuzhSccdpgNq2iY03V-Cx7TT1I1zsfaBILs3TLWvGYvBbjTCFkp0fGKyw_V25TXWzldj8cO9hjqGtD5k63EFc-O44uNnAYeeKKR0mTAEOd3zt5OiJFezqWVmYxNn8E";// Replace with your actual access token
// Initialize a DropboxClient with the provided access token.
using (var dbx = new DropboxClient(accessToken))
{
    // Upload the PDF to Dropbox.
    var uploadResult = await dbx.Files.UploadAsync(
        "/path/to/save/Sample.pdf",
        WriteMode.Overwrite.Instance,
        body: new MemoryStream(stream.ToArray()));
}

