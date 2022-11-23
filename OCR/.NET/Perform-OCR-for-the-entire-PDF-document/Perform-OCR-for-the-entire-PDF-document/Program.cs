// See https://aka.ms/new-console-template for more information

using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Parsing;

string tesseractBinariesPath = Path.GetFullPath("../../../../../Tesseractbinaries/Windows");
string tessdataPath = Path.GetFullPath("../../../../../Tessdata");

//Initialize the OCR processor with tesseract binaries folder path.
using (OCRProcessor processor = new OCRProcessor(tesseractBinariesPath))
{
    //Get stream from an existing PDF document. 
    FileStream stream = new FileStream(Path.GetFullPath(@"../../../Input.pdf"), FileMode.Open);

    //Load the PDF document.
    PdfLoadedDocument document = new PdfLoadedDocument(stream);

    //Set OCR language.
    processor.Settings.Language = Languages.English;

    //Perform OCR with input document and tessdata (Language packs).
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
