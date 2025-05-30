using System;
using System.Diagnostics;
using System.IO;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;

namespace PDFCompression;

public class Program
{
    public static void Main(string[] args)
    {
        CompressPdf();
    }

    public static void CompressPdf()
    {
        string path = Path.GetFullPath(@"Input.pdf");
        Console.WriteLine($"'{path}' pdf compression started.");

        Stopwatch stopwatch = Stopwatch.StartNew();
        FileStream inputDocument = new FileStream(path, FileMode.Open, FileAccess.Read);
        Console.WriteLine($"Original   file size: {inputDocument.Length:N0}");

        PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputDocument);

        // Create a new compression option.
        PdfCompressionOptions options = new PdfCompressionOptions
        {
            // Enable image compression.
            CompressImages = true,
            // Set the image quality.
            ImageQuality = 30,
            // Optimize fonts in the PDF document.
            OptimizeFont = true,
            // Optimize page contents.
            OptimizePageContents = true,
            // Remove metadata from the PDF document.
            RemoveMetadata = true
        };

        // Compress the PDF document.
        loadedDocument.Compress(options);

        // Save the PDF document.
        MemoryStream outputDocument = new MemoryStream();

        // Save the PDF document to memory stream.
        loadedDocument.Save(outputDocument);

        stopwatch.Stop();
        Console.WriteLine($"Compressed file size: {outputDocument.Length:N0}");
        Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}");

        // Clean up resources.
        outputDocument.Close();
        loadedDocument.Close(true);
        inputDocument.Close();
    }
}