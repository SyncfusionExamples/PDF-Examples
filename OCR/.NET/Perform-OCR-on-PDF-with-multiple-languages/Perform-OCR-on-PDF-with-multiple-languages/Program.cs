using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

// Load the PDF document
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Initialize OCR processor
    OCRProcessor processor = new OCRProcessor();
    //Sets Unicode font to preserve the Unicode characters in a PDF document.
    processor.UnicodeFont = new PdfTrueTypeFont(Path.GetFullPath(@"Data/ARIALUNI.ttf"), 8);
    // Set OCR language
    processor.Settings.Language = "eng+deu+ara+ell+fra"; // English, German, Arabic, Greek, French
    // Set the path to the Tesseract language data folder
    processor.TessDataPath = Path.GetFullPath(@"../../Tessdata");
    // Perform OCR
    processor.PerformOCR(loadedDocument);
    // Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
