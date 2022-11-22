// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Parsing;

string tesseractBinariesPath = Path.GetFullPath("../../../../../Tesseractbinaries/Windows");
string tessdataPath = Path.GetFullPath("../../../../../Tessdata");

//Initialize the OCR processor by providing the path of the tesseract.
using (OCRProcessor processor = new OCRProcessor(tesseractBinariesPath))
{
    //Get stream from the existing PDF document. 
    FileStream stream = new FileStream(Path.GetFullPath(@"../../../Input.pdf"), FileMode.Open);

    //Load the PDF document. 
    PdfLoadedDocument document = new PdfLoadedDocument(stream);

    //Set OCR language to process.
    processor.Settings.Language = Languages.English;

    //Set the bounds to perform OCR. 
    Syncfusion.Drawing.RectangleF rect = new Syncfusion.Drawing.RectangleF(0, 100, 950, 150);

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

    //Create file stream.
    using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
    {
        //Save the PDF document to file stream.
        document.Save(outputFileStream);
    }

    //Close the document.
    document.Close(true);
}

