using Syncfusion.Drawing;
using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Parsing;


string tessdataPath = Path.GetFullPath(@"Tessdata");

//Initialize the OCR processor by providing the path of tesseract.
using (OCRProcessor processor = new OCRProcessor())
{
    //Load the PDF document. 
    PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf"));

    //Set OCR language to process.
    processor.Settings.Language = Languages.English;

    //Create the layout result. 
    OCRLayoutResult layoutResult = new OCRLayoutResult();

    //Process OCR by providing the PDF document, data dictionary, and language.
    processor.PerformOCR(loadedDocument, tessdataPath, out layoutResult);

    //Get OCRed line collection from first page.
    OCRLineCollection lines = layoutResult.Pages[0].Lines;

    //Get each OCRed line and its bounds.
    foreach (Line line in lines)
    {
        string text = line.Text;
        RectangleF bounds = line.Rectangle;
    }

    //Close the PDF document. 
    loadedDocument.Close(true);
}
