using Syncfusion.Pdf;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");
        // Get input and output folder
        string inputFolder = Path.GetFullPath("../../../Data/");
        string outputFolder = Path.GetFullPath("../../../Output/");
        string fileName = "MergePdf.pdf";
        string inputFile = string.Empty;
        Directory.CreateDirectory(outputFolder);
        // Get all .pdf files in the Data folder
        string[] source = Directory.GetFiles(inputFolder, "*.pdf");
        Stream[] streams = new Stream[source.Length];
        for (int i = 0; i < source.Length; i++)
        {
            //Open the PDF document as a stream.
            streams[i] = new FileStream(source[i], FileMode.Open, FileAccess.Read, FileShare.Read);
            inputFile += Path.GetFileName(source[i]);
            inputFile = (i + 1 < source.Length) ? inputFile += ", " : inputFile += string.Empty;
        }
        string outputPath = Path.Combine(outputFolder, fileName);
        Stopwatch stopwatch = Stopwatch.StartNew();
        try
        {
            //Create a new PDF document.
            PdfDocument finalDoc = new PdfDocument();
            PdfDocument.Merge(finalDoc, streams);
            //Save the final document.
            finalDoc.Save(outputPath);
            //Close the document.
            finalDoc.Close(true);
            stopwatch.Stop();
            Console.WriteLine($"{inputFile} Merge Documents in {stopwatch.Elapsed.TotalSeconds} seconds");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing {fileName}: {ex.Message}");
        }
    }
}