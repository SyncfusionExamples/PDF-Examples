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
        // Open the file specified by the path for reading using a FileStream
        using (FileStream inputDocument = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
        {
            // Load the PDF document from the input file stream
            using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputDocument))
            {
                // Create a new instance of PdfCompressionOptions to specify compression settings
                PdfCompressionOptions options = new PdfCompressionOptions
                {
                    // Enable image compression in the PDF document
                    CompressImages = true,
                    // Set the image quality to 30 (on a scale where lower values reduce quality)
                    ImageQuality = 30,
                    // Optimize the font usage in the PDF document
                    OptimizeFont = true,
                    // Optimize the contents of each page in the PDF document
                    OptimizePageContents = true,
                    // Remove metadata from the PDF document to reduce its size
                    RemoveMetadata = true
                };

                // Apply the compression options to the loaded PDF document
                loadedDocument.Compress(options);

                // Create a file stream to store the compressed PDF document
                using (FileStream outputDocument = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
                {
                    // Save the compressed PDF document to the output stream
                    loadedDocument.Save(outputDocument);
                }
            }
        }
    }
}