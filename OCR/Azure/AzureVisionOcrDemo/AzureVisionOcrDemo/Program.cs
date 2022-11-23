using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Parsing;
using System;
using System.IO;

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

                //Set OCR language
                processor.Settings.Language = Languages.English;

                //Initialize the Azure vision OCR external engine.
                IOcrEngine azureOcrEngine = new AzureExternalOcrEngine();

                processor.ExternalEngine = azureOcrEngine;

                //Perform OCR with input document.
                processor.PerformOCR(lDoc);

                if (File.Exists("../../../output/Region.pdf"))
                    File.Delete("../../../output/Region.pdf");

                FileStream outputStream = new FileStream("../../../output/Region.pdf", FileMode.CreateNew);

                //Save the document into stream.
                lDoc.Save(outputStream);

                //If the position is not set to '0' then the PDF will be empty. 
                outputStream.Position = 0;

                //Close the document. 
                lDoc.Close(true);
                outputStream.Close();
            }
        }
    }
}
