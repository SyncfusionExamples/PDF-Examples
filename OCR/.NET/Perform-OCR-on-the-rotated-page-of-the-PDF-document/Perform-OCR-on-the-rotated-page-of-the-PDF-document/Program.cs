using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Parsing;
using System.Diagnostics;
using System.IO;

string tessdataPath = Path.GetFullPath(@"Tessdata");

//Initialize the OCR processor by providing the path of tesseract.
using (OCRProcessor processor = new OCRProcessor(Path.GetFullPath()))
//Get stream from an existing PDF document.  
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Set OCR language to process.
    processor.Settings.Language = Languages.English;

    //Set the Page Segment Mode.
    processor.Settings.PageSegment = PageSegMode.AutoOsd;

    //Process OCR by providing the PDF document, data dictionary, and language.
    processor.PerformOCR(loadedDocument, tessdataPath);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));

    //Close the document.
    loadedDocument.Close(true);

}
