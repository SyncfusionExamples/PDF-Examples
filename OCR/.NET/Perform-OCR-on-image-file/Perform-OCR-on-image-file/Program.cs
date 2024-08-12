// See https://aka.ms/new-console-template for more information

using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Graphics;
using System.Drawing;

string tessdataPath = Path.GetFullPath("../../../../../Tessdata");

//Initialize the OCR processor by providing the path of the tesseract binaries.
using (OCRProcessor processor = new OCRProcessor())
{
    //Get stream from the image file. 
    FileStream stream = new FileStream(Path.GetFullPath(@"Data/Input.jpg"), FileMode.Open);

    //Set OCR language to process.
    processor.Settings.Language = Languages.English;

    //Sets Unicode font to preserve the Unicode characters in a PDF document.
    FileStream fontStream = new FileStream(Path.GetFullPath(@"Data/ARIALUNI.ttf"), FileMode.Open);

    processor.UnicodeFont = new PdfTrueTypeFont(fontStream, 8);

    //Perform the OCR process for an image steam.
    string ocrText = processor.PerformOCR(stream, tessdataPath);

    //Write the OCR'ed text in text file. 
    using (StreamWriter writer = new StreamWriter(Path.GetFullPath("Output/Output.txt"), true))
    {
        writer.WriteLine(ocrText);
    }
}
