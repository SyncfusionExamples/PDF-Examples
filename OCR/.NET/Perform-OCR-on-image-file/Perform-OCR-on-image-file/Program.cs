using Syncfusion.OCRProcessor;

//Create an OCR processor instance.
using (OCRProcessor processor = new OCRProcessor())
{
    //Open the input image as a file stream.
    FileStream stream = new FileStream(Path.GetFullPath(@"Data/Input.jpg"), FileMode.Open);
    //Specify English as the language for text recognition.
    processor.Settings.Language = Languages.English;
    //Extract text from the image using the OCR engine and tessdata path.
    string ocrText = processor.PerformOCR(stream, processor.TessDataPath);
    //Save the recognized text to a text file.
    File.WriteAllText(Path.GetFullPath(@"Output/Output.txt"), ocrText);
}
