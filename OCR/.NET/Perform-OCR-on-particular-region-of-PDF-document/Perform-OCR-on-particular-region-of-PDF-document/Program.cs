using Syncfusion.Drawing;
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

    //Set the bounds to perform OCR. 
    RectangleF rect = new RectangleF(0, 100, 950, 150);

    //Assign rectangles to the page.
    List<PageRegion> pageRegions = new List<PageRegion>();

    //Create page region.
    PageRegion region = new PageRegion();

    //Set page index.
    region.PageIndex = 0;

    //Set page region.
    region.PageRegions = new RectangleF[] { rect };

    //Add region to page region.
    pageRegions.Add(region);

    //Set page regions.
    processor.Settings.Regions = pageRegions;

    //Perform OCR with input document and tessdata (Language packs).
    processor.PerformOCR(document, tessdataPath);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));

    //Close the document.
    document.Close(true);
}

