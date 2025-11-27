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
                // Load or open  document
                PdfLoadedDocument document = new PdfLoadedDocument(inputPath);
                // Save the document to Output folder
                document.Save(outputPath);
                stopwatch.Stop();
                Console.WriteLine($"{fileName} open and saved in {stopwatch.Elapsed.TotalSeconds} seconds");
                document.Close(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing {fileName}: {ex.Message}");
            }
        }
    }
}