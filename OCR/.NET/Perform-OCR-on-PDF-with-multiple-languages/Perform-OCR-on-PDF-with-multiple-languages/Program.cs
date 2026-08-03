using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Open the existing PDF document.
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Create an OCR processor instance.
    OCRProcessor processor = new OCRProcessor();
    //Assign a Unicode font to retain multilingual characters in the OCR output PDF.
    processor.UnicodeFont = new PdfTrueTypeFont(Path.GetFullPath(@"Data/ARIALUNI.ttf"), 8);
    //Specify the languages to be recognized during OCR processing.
    processor.Settings.Language = "eng+spa+deu+fra+chi_sim+ara";
    //Set the directory containing Tesseract language data files.
    processor.TessDataPath = Path.GetFullPath(@"Tessdata");
    //Run OCR on the PDF document and make its content searchable.
    processor.PerformOCR(loadedDocument);
    //Save the OCR-processed PDF to the output location.
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}