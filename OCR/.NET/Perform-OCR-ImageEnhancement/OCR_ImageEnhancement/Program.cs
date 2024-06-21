
using OCR_ImageEnhancement;
using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Parsing;


//Initialize the OCR processor.
using (OCRProcessor processor = new OCRProcessor())
{
    //Load an existing PDF document.
    FileStream stream = new FileStream("../../../Carte grise Peugeot 108.pdf", FileMode.Open);
    PdfLoadedDocument document = new PdfLoadedDocument(stream);
    //Set OCR language.
    processor.Settings.Language = Languages.English;
    processor.ImageProcessor = new ImageProcessor();
    //Perform OCR with input document and tessdata (Language packs).
    string text = processor.PerformOCR(document, 0, 0, processor.TessDataPath);
    //Create file stream.
    using (FileStream outputFileStream = new FileStream("../../../Output.pdf", FileMode.Create, FileAccess.ReadWrite))
    {
        //Save the PDF document to file stream.
        document.Save(outputFileStream);
    }
    //Close the document.
    document.Close(true);
    File.WriteAllText("../../../Output.txt", text);
}