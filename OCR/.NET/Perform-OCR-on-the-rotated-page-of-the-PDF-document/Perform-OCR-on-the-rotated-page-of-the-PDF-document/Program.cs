// See https://aka.ms/new-console-template for more information

using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Parsing;

string tesseractBinariesPath = Path.GetFullPath("../../../../../Tesseractbinaries/Windows");
string tessdataPath = Path.GetFullPath("../../../../../Tessdata");

//Initialize the OCR processor by providing the path of tesseract.
using (OCRProcessor processor = new OCRProcessor(Path.GetFullPath(tesseractBinariesPath))
{
    //Get stream from an existing PDF document.  
    FileStream stream = new FileStream(Path.GetFullPath(@"../../../Input.pdf"), FileMode.Open);

    //Load the PDF document. 
    PdfLoadedDocument loadedDocument = new PdfLoadedDocument(stream);

    //Set OCR language to process.
    processor.Settings.Language = Languages.English;

    //Set the Page Segment Mode.
    processor.Settings.PageSegment = PageSegMode.AutoOsd;

    //Process OCR by providing the PDF document, data dictionary, and language.
    processor.PerformOCR(loadedDocument, tessdataPath);

    //Create file stream.
    using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
    {
        //Save the PDF document to file stream.
        loadedDocument.Save(outputFileStream);
    }

    //Close the document.
    loadedDocument.Close(true);

}
