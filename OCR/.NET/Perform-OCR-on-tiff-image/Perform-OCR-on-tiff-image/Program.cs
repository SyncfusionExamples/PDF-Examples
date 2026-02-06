using Syncfusion.OCRProcessor;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

string filePath = Path.GetFullPath(@"Data/multipage_tiff_example.tif"); ;

var output = new StringBuilder();

using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
using (Image img = Image.FromStream(fs, useEmbeddedColorManagement: false, validateImageData: false))
using (OCRProcessor processor = new OCRProcessor())
{
    processor.TessDataPath = Path.GetFullPath(@"TessdataBest/");
    processor.Settings.Language = Languages.English;
    processor.Settings.TesseractVersion = TesseractVersion.Version5_0;

    // Determine how many frames/pages the TIFF contains.
    int frameCount = img.GetFrameCount(FrameDimension.Page);
    if (frameCount <= 1)
    {
        // Some TIFFs may use other dimensions; try Time/Resolution as fallback
        frameCount = Math.Max(frameCount, img.GetFrameCount(FrameDimension.Time));
        frameCount = Math.Max(frameCount, img.GetFrameCount(FrameDimension.Resolution));
    }
    if (frameCount < 1) frameCount = 1;

    for (int i = 0; i < frameCount; i++)
    {
        // Prefer Page dimension
        try { img.SelectActiveFrame(FrameDimension.Page, i); }
        catch { /* fallback if needed */ }

        // Clone the selected frame to a standalone Bitmap for OCR (important for some engines)
        using (Bitmap frameBmp = new Bitmap(img.Width, img.Height))
        using (Graphics g = Graphics.FromImage(frameBmp))
        {
            g.DrawImage(img, 0, 0, img.Width, img.Height);
            MemoryStream ms = new MemoryStream();
            frameBmp.Save(ms, ImageFormat.Png);
            ms.Position = 0;
            string pageText = processor.PerformOCR(ms, processor.TessDataPath);
            output.AppendLine($"--- Page {i + 1} ---");
            output.AppendLine(pageText ?? string.Empty);
            output.AppendLine();
        }
    }
}
File.WriteAllText("Output.txt", output.ToString());
