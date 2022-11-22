// See https://aka.ms/new-console-template for more information

using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Parsing;

string tesseractBinariesPath = Path.GetFullPath("../../../../../Tesseractbinaries/Windows");
string tessdataPath = Path.GetFullPath("../../../../../Tessdata");

//Initialize the OCR processor by providing the path of the tesseract.
using (OCRProcessor processor = new OCRProcessor(tesseractBinariesPath))
{
    //Get stream from an existing PDF document. 
    FileStream stream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open);

    //Load the PDF document. 
    PdfLoadedDocument document = new PdfLoadedDocument(stream);

    //Set OCR language to process.
    processor.Settings.Language = Languages.English;

    //Set custom temp file path location.
    processor.Settings.TempFolder = Path.GetFullPath("D:/Temp/");

    //Process OCR by providing the PDF document, data dictionary, and language.
    processor.PerformOCR(document, tessdataPath);

    //Create file stream.
    using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
    {
        //Save the PDF document to file stream.
        document.Save(outputFileStream);
    }

    //Close the document.
    document.Close(true);
}
