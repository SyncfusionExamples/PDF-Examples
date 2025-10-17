using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Parsing;

// Initialize the OCR processor
using (OCRProcessor processor = new OCRProcessor())
{
    // Load the existing PDF document
    using (PdfLoadedDocument pdfLoadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
    {
        // Set OCR language to process
        processor.Settings.Language = Languages.English;

        processor.Settings.PageSegment = PageSegMode.SparseTextOsd;

        // Process OCR by providing the PDF document
        processor.PerformOCR(pdfLoadedDocument, processor.TessDataPath, out OCRLayoutResult layoutResult);
        string ocrText = string.Join("\n", layoutResult.Pages[0].Lines.Select(line => line.Text));

        //Save the PDF document
        pdfLoadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
        //Close the document.
        pdfLoadedDocument.Close(true);
        File.WriteAllText(Path.GetFullPath(@"Output/Output.txt"), ocrText);
    }
}
