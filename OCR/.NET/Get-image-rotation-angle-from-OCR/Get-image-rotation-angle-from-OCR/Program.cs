using Syncfusion.OCRProcessor;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using System.Reflection.Metadata;

//Initialize the OCR processor.
using (OCRProcessor processor = new OCRProcessor())
{
    //Load the existing PDF document
    PdfLoadedDocument document = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf"));
    //Set the OCR language.
    processor.Settings.Language = Languages.English;
    //Set the Unicode font to preserve the Unicode characters in a PDF document.
    processor.TesseractPath = Path.GetFullPath(@"TesseractBinaries/");
    processor.Settings.PageSegment = PageSegMode.AutoOsd;
    processor.PerformOCR(document, 0, 0, Path.GetFullPath(@"Tessdata"), out OCRLayoutResult result);
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
    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
