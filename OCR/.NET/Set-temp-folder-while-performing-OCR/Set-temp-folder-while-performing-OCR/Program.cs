using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Parsing;


string tessdataPath = Path.GetFullPath(@"Tessdata");

//Initialize the OCR processor by providing the path of the tesseract.
using (OCRProcessor processor = new OCRProcessor())
{
    //Load the PDF document. 
    PdfLoadedDocument document = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf"));

    //Set OCR language to process.
    processor.Settings.Language = Languages.English;

    //Set custom temp file path location.
    processor.Settings.TempFolder = Path.GetFullPath(@"D:/Temp/");

    //Process OCR by providing the PDF document, data dictionary, and language.
    processor.PerformOCR(document, tessdataPath);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));

    //Close the document.
    document.Close(true);
}
