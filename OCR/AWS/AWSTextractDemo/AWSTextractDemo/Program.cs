using System.IO;
using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Parsing;


namespace OCR.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize the OCR processor.
            using (OCRProcessor processor = new OCRProcessor())
            {
                //Load a PDF document.
                FileStream stream = new FileStream("../../../Region.pdf", FileMode.Open);

                PdfLoadedDocument lDoc = new PdfLoadedDocument(stream);

                //Set the OCR language.
                processor.Settings.Language = Languages.English;

                //Initialize the  AWS Textract external OCR engine.
                IOcrEngine azureOcrEngine = new AWSExternalOcrEngine();

                processor.ExternalEngine = azureOcrEngine;

                //Perform OCR with input document.
                string text = processor.PerformOCR(lDoc);

                if (File.Exists("../../../Output/Region.pdf"))
                    File.Delete("../../../Output/Region.pdf");

                FileStream fileStream = new FileStream("../../../Output/Region.pdf", FileMode.CreateNew);

                //Save the document into stream.
                lDoc.Save(fileStream);

                //Close the document.
                lDoc.Close();
                stream.Dispose();
                fileStream.Dispose();


            }
        }
    }
}
