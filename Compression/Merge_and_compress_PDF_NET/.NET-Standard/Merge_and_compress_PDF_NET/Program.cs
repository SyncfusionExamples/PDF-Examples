using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;

namespace Merge_and_compress_PDF_NET {
    internal class Program {
        static void Main(string[] args) {
            // Create a PDF document. 
            using (PdfDocument finalDocument = new PdfDocument()) {

                // Get the stream from an existing PDF documents. 
                using (FileStream firstStream = new FileStream(Path.GetFullPath("../../../Data/imageDoc.pdf"), FileMode.Open, FileAccess.Read))

                using (FileStream secondStream = new FileStream(Path.GetFullPath("../../../Data/imageDoc.pdf"), FileMode.Open, FileAccess.Read)) {

                    // Create a PDF stream for merging. 
                    Stream[] streams = { firstStream, secondStream };

                    // Merge PDF documents. 
                    PdfDocumentBase.Merge(finalDocument, streams);

                    // Save the document into a stream. 
                    MemoryStream outputStream = new MemoryStream();
                    finalDocument.Save(outputStream);

                    // Create a new PdfLoadedDocument object from the file stream. 
                    using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(outputStream)) {

                        // Create a new PdfCompressionOptions object. 
                        PdfCompressionOptions options = new PdfCompressionOptions();

                        // Enable the compress image and set image quality. 
                        options.CompressImages = true;
                        options.ImageQuality = 50;

                        // Compress the PDF document. 
                        loadedDocument.Compress(options);

                        // Save the document into memory stream. 
                        using (FileStream memoryStream = new FileStream("Output.pdf", FileMode.Create, FileAccess.ReadWrite)) {
                            loadedDocument.Save(memoryStream);
                        }
                    }
                }
            }
        }
    }
}