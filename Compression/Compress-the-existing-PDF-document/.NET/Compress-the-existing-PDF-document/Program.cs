using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Load the PDF document
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Create a new PdfCompressionOptions object
    PdfCompressionOptions options = new PdfCompressionOptions();
    //Set the image quality
    options.ImageQuality = 50;
    // Compress the PDF document
    loadedDocument.Compress(options);
    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}