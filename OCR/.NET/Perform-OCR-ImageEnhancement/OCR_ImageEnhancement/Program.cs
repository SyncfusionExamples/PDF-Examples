using OCR_ImageEnhancement;
using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Parsing;


//Initialize the OCR processor.
using (OCRProcessor processor = new OCRProcessor())
{
    //Load an existing PDF document.
    PdfLoadedDocument document = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf"));
    //Set OCR language.
    processor.Settings.Language = Languages.English;
    // Set the page segmentation mode for the OCR processor.
    // PageSegMode.AutoOsd determines the best way to segment the page automatically
    processor.Settings.PageSegment = PageSegMode.AutoOsd;
    //Initialize the OCR image processor.
    processor.ImageProcessor = new ImageProcessor();
    //Perform OCR with input document and tessdata (Language packs).
    string text = processor.PerformOCR(document, 0, 0, processor.TessDataPath);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
    //Close the document.
    document.Close(true);
    File.WriteAllText(Path.GetFullPath(@"Output/Output.txt"), text);
}