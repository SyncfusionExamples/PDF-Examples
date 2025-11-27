using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");
        string inputFolder = Path.GetFullPath("../../../Data/");
        string outputFolder = Path.GetFullPath("../../../Output/");
        Directory.CreateDirectory(outputFolder);
        // Get all .pdf files in the Data folder
        string[] files = Directory.GetFiles(inputFolder, "*.pdf");
        foreach (string inputPath in files)
        {
            string fileName = Path.GetFileName(inputPath);
            string outputPath = Path.Combine(outputFolder, fileName);
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {               
                // Load the PDF document
                PdfLoadedDocument document = new PdfLoadedDocument(inputPath);
                // Create compression options
                PdfCompressionOptions options = new PdfCompressionOptions();
                options.ImageQuality = 50; // Set the image quality to 50% for compression
                // Compress the PDF document
                document.Compress(options);
                // Save the compressed document to Output folder
                document.Save(outputPath);
                Console.WriteLine($"{fileName} Compress-pdf Time: {stopwatch.Elapsed.TotalSeconds:F2} seconds\n");
                document.Close(true);
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                Console.WriteLine($" Error processing {fileName}: {ex.Message}\n");
            }
        }     
    }   
}