
using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Parsing;


// Initialize the OCR processor within a using block to ensure resources are properly disposed
using (OCRProcessor ocrProcessor = new OCRProcessor())
{
    // Set the Unicode font for the OCR processor using a TrueType font file
    ocrProcessor.UnicodeFont = new Syncfusion.Pdf.Graphics.PdfTrueTypeFont(
        new FileStream(Path.GetFullPath(@"Data/arialuni.ttf"), FileMode.Open), // Path to the TrueType font file
        12 // Font size
    );

    // Open the PDF file to be processed
    FileStream fileStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open);

    // Load the PDF document from the file stream
    PdfLoadedDocument loadedDocument = new PdfLoadedDocument(fileStream);

    // Configure OCR settings
    OCRSettings ocrSettings = new OCRSettings();

    // Specify the languages to be used for OCR
    ocrSettings.Language = "eng+deu+ara+ell+fra"; // English, German, Arabic, Greek, French

    // Apply the OCR settings to the OCR processor
    ocrProcessor.Settings = ocrSettings;

    // Perform OCR on the loaded PDF document, providing the path to the tessdata directory
    ocrProcessor.PerformOCR(loadedDocument, "tessdata");

    // Create a file stream to save the OCR-processed PDF
    FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create);

    // Save the OCR-processed document to the file stream
    loadedDocument.Save(outputFileStream);

    // Close the loaded document and commit changes
    loadedDocument.Close(true);

    // Close the file streams
    outputFileStream.Close();
    fileStream.Close();
}



