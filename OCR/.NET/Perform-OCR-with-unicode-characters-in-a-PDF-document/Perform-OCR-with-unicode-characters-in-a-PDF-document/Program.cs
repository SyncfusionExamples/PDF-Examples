// See https://aka.ms/new-console-template for more information

using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

string tesseractBinariesPath = Path.GetFullPath("../../../../../Tesseractbinaries/Windows");
string tessdataPath = Path.GetFullPath("../../../../../Tessdata");

//Initialize the OCR processor by providing the path of tesseract.
using (OCRProcessor processor = new OCRProcessor(tesseractBinariesPath))
{
    //Get stream from an existing PDF document. 
    FileStream stream = new FileStream(Path.GetFullPath(@"../../../UnicodePDF.pdf"), FileMode.Open);

    //Load the PDF document. 
    PdfLoadedDocument loadedDocument = new PdfLoadedDocument(stream);

    //Sets Unicode font to preserve the Unicode characters in a PDF document.
    FileStream fontStream = new FileStream(Path.GetFullPath(@"../../../ARIALUNI.ttf"), FileMode.Open);

    //Set the font for unicode text. 
    processor.UnicodeFont = new PdfTrueTypeFont(fontStream, 8);

    //Set OCR language to process
    processor.Settings.Language = Languages.English;

    //Process OCR by providing the PDF document, data dictionary, and language
    string ocrText = processor.PerformOCR(loadedDocument, tessdataPath);

    //Create file stream.
    using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
    {
        //Save the PDF document to file stream.
        loadedDocument.Save(outputFileStream);
    }

    //Close the document.
    loadedDocument.Close(true);
}
