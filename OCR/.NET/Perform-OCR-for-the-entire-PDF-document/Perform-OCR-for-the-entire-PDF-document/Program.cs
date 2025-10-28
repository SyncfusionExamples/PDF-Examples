using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Parsing;

// Initialize the OCR processor
using (OCRProcessor processor = new OCRProcessor())
{
    // Load the PDF document
    using (PdfLoadedDocument pdfLoadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
    {
        // Set OCR language to process
        processor.Settings.Language = Languages.English;
        // Process OCR by providing the PDF document
        processor.PerformOCR(pdfLoadedDocument);
        //Save the PDF document
        pdfLoadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
    }
}