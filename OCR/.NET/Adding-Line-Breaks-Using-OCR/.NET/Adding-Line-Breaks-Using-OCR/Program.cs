using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Parsing;

// Initialize the OCR processor
using (OCRProcessor processor = new OCRProcessor())
{
    // Load the existing PDF document
    using (FileStream stream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open))
    {
        PdfLoadedDocument pdfLoadedDocument = new PdfLoadedDocument(stream);

        // Set OCR language to process
        processor.Settings.Language = Languages.English;

        processor.Settings.PageSegment = PageSegMode.SparseTextOsd;

        // Process OCR by providing the PDF document
        processor.PerformOCR(pdfLoadedDocument, processor.TessDataPath, out OCRLayoutResult layoutResult);
        string ocrText = string.Join("\n", layoutResult.Pages[0].Lines.Select(line => line.Text));


        //Create file stream.
        using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
        {
            //Save the PDF document to file stream.
            pdfLoadedDocument.Save(outputFileStream);
        }
        //Close the document.
        pdfLoadedDocument.Close(true);
        File.WriteAllText(Path.GetFullPath(@"Output/Output.txt"), ocrText);
    }
}
