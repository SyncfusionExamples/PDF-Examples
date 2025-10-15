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
                //Load an existing PDF document.
                FileStream stream = new FileStream(Path.GetFullPath(@"Data/Region.pdf"), FileMode.Open);
                PdfLoadedDocument lDoc = new PdfLoadedDocument(stream);

                //Set the OCR language.
                processor.Settings.Language = Languages.English;

                //Initialize the AWS Textract external OCR engine.
                IOcrEngine azureOcrEngine = new AWSExternalOcrEngine();
                processor.ExternalEngine = azureOcrEngine;

                //Perform OCR with input document.
                string text = processor.PerformOCR(lDoc);

                //Save the document
                lDoc.Save(Path.GetFullPath(@"Output/Output.pdf"));

                //Close the document.
                lDoc.Close();
                stream.Dispose();
            }
        }
    }
}

