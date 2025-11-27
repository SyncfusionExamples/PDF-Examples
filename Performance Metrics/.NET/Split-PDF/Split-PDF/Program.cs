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
                PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputPath);
                loadedDocument.Split(outputPath);
                stopwatch.Stop();
                Console.WriteLine($"{fileName} Split PDF documents in {stopwatch.Elapsed.TotalSeconds} seconds");
                // Close the original document
                loadedDocument.Close(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing {fileName}: {ex.Message}");
            }
        }
    }
}