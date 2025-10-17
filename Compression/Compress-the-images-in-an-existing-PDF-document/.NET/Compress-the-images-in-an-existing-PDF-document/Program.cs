using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Create a new PdfCompressionOptions object.
    PdfCompressionOptions options = new PdfCompressionOptions();

    // Enable image compression and set image quality.
    options.CompressImages = true;
    options.ImageQuality = 50;

    // Enable font optimization.
    options.OptimizeFont = true;

    // Enable page content optimization.
    options.OptimizePageContents = true;

    // Remove metadata from the PDF.
    options.RemoveMetadata = true;

    // Compress the PDF document.
    loadedDocument.Compress(options);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}