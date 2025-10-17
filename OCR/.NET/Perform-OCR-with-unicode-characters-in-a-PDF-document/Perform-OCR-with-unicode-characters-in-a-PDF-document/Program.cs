using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

string tessdataPath = Path.GetFullPath(@"Tessdata");

//Initialize the OCR processor by providing the path of tesseract.
using (OCRProcessor processor = new OCRProcessor())
{
    //Load the PDF document. 
    PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/UnicodePDF.pdf"));

    //Sets Unicode font to preserve the Unicode characters in a PDF document.
    FileStream fontStream = new FileStream(Path.GetFullPath(@"Data/ARIALUNI.ttf"), FileMode.Open);

    //Set the font for unicode text. 
    processor.UnicodeFont = new PdfTrueTypeFont(fontStream, 8);

    //Set OCR language to process
    processor.Settings.Language = Languages.English;

    //Process OCR by providing the PDF document, data dictionary, and language
    string ocrText = processor.PerformOCR(loadedDocument, tessdataPath);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));

    //Close the document.
    loadedDocument.Close(true);
}
