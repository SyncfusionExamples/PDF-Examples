// See https://aka.ms/new-console-template for more information

using Syncfusion.OCRProcessor;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Drawing;

//Initialize the OCR processor by providing the path of the tesseract binaries.
using (OCRProcessor processor = new OCRProcessor())
{
    //Get stream from an image file. 
    FileStream imageStream = new FileStream(Path.GetFullPath(@"../../../Input.jpg"), FileMode.Open);    

    //Set OCR language to process.
    processor.Settings.Language = Languages.English;

    //Sets Unicode font to preserve the Unicode characters in a PDF document.
    FileStream fontStream = new FileStream(Path.GetFullPath(@"../../../ARIALUNI.ttf"), FileMode.Open);

    //Set the unicode font. 
    processor.UnicodeFont = new PdfTrueTypeFont(fontStream, true, PdfFontStyle.Regular, 10);

    //Set the PDF conformance level.
    processor.Settings.Conformance = PdfConformanceLevel.Pdf_A1B;

    //Process OCR by providing the bitmap image.  
    PdfDocument document = processor.PerformOCR(imageStream);

    //Create file stream.
    using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
    {
        //Save the PDF document to file stream.
        document.Save(outputFileStream);
    }

    //Close the document.
    document.Close(true);
}
