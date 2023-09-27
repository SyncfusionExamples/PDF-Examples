// See https://aka.ms/new-console-template for more information

using Syncfusion.OCRProcessor;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using System.Reflection.Metadata;

//Initialize the OCR processor.
using (OCRProcessor processor = new OCRProcessor())
{
    //Get the stream from an image file. 
    FileStream stream = new FileStream(@"../../../Input.pdf", FileMode.Open);
    //Set the OCR language to process.
    PdfLoadedDocument document = new PdfLoadedDocument(stream);
    //Set the OCR language.
    processor.Settings.Language = Languages.English;
    //Set the Unicode font to preserve the Unicode characters in a PDF document.
    processor.TesseractPath = @"../../../TesseractBinaries/";
    processor.Settings.PageSegment = PageSegMode.AutoOsd;
    processor.PerformOCR(document, 0, 0, @"../../../Tessdata", out OCRLayoutResult result);
    float angle = 0;
    if (result != null)
    {
        foreach (var page in result.Pages)
        {
            angle = page.ImageRotation;
            if (angle == 180)
            { document.Pages[0].Rotation = PdfPageRotateAngle.RotateAngle90; }
            if (angle == 90)
            { document.Pages[0].Rotation = PdfPageRotateAngle.RotateAngle270; }
        }
    }
    
    //Create file stream.
    using (FileStream outputFileStream = new FileStream("../../../Output.pdf", FileMode.Create, FileAccess.ReadWrite))
    {
        //Save the PDF document to file stream.
        document.Save(outputFileStream);
    }
}
