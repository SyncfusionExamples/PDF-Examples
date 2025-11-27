using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using System.Diagnostics;
using Syncfusion.Drawing; 

class Program
{    
    private static readonly PdfFont WatermarkFont = new PdfStandardFont(PdfFontFamily.Helvetica, 60, PdfFontStyle.Bold);
    private static readonly PdfBrush WatermarkBrush = new PdfSolidBrush(Color.Gray);
    private const string WatermarkText = "CONFIDENTIAL";

    static void Main()
    {       
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");
        string inputFolder = Path.GetFullPath("../../../Data/");
        string outputFolder = Path.GetFullPath("../../../Output/");
        Directory.CreateDirectory(outputFolder);
        string[] files = Directory.GetFiles(inputFolder, "*.pdf");
        foreach (string inputPath in files)
        {
            string fileName = Path.GetFileName(inputPath);
            string outputPath = Path.Combine(outputFolder, fileName);
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                PdfLoadedDocument document = new PdfLoadedDocument(inputPath);
                // Apply watermark to all pages
                foreach (PdfPageBase page in document.Pages)
                {
                    AddWatermark(page.Graphics, page.Size);
                }
                document.Save(outputPath);
                stopwatch.Stop();
                Console.WriteLine($"{fileName} Apply watermark processed in {stopwatch.Elapsed.TotalSeconds:F2} seconds");
                document.Close(true);
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                Console.WriteLine($" Error processing {fileName}: {ex.Message}");
            }
        }
    }
    static void AddWatermark(PdfGraphics graphics, SizeF pageSize)
    {
        PdfGraphicsState state = graphics.Save();
        graphics.SetTransparency(0.3f);

        SizeF textSize = WatermarkFont.MeasureString(WatermarkText);

        graphics.TranslateTransform(pageSize.Width / 2, pageSize.Height / 2);
        graphics.RotateTransform(-45);
        graphics.TranslateTransform(-textSize.Width / 2, -textSize.Height / 2);

        graphics.DrawString(WatermarkText, WatermarkFont, WatermarkBrush, 0, 0);
        graphics.Restore(state);
    }
}
