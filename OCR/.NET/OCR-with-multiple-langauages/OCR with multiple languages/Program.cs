using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Parsing;

// Initialize the OCR processor within a using block to ensure resources are properly disposed
using (OCRProcessor ocrProcessor = new OCRProcessor())
{
    // Set the Unicode font for the OCR processor using a TrueType font file
    ocrProcessor.UnicodeFont = new Syncfusion.Pdf.Graphics.PdfTrueTypeFont(
        new FileStream(Path.GetFullPath(@"Data/arialuni.ttf"), FileMode.Open),12 );

    // Load the PDF document
    PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf"));

    // Configure OCR settings
    OCRSettings ocrSettings = new OCRSettings();

    // Specify the languages to be used for OCR
    ocrSettings.Language = "eng+deu+ara+ell+fra";

    // Apply the OCR settings to the OCR processor
    ocrProcessor.Settings = ocrSettings;

    // Perform OCR on the loaded PDF document, providing the path to the tessdata directory
    ocrProcessor.PerformOCR(loadedDocument, "tessdata");

    // Save the OCR-processed document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));

    // Close the loaded document and commit changes
    loadedDocument.Close(true);
}



