// See https://aka.ms/new-console-template for more information

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
                FileStream stream = new FileStream("../../../Region.pdf", FileMode.Open);
                PdfLoadedDocument lDoc = new PdfLoadedDocument(stream);

                //Set OCR language.
                processor.Settings.Language = Languages.English;

                //Initialize the Azure vision OCR external engine.
                IOcrEngine azureOcrEngine = new AzureExternalOcrEngine();
                processor.ExternalEngine = azureOcrEngine;

                //Perform OCR.
                processor.PerformOCR(lDoc);

                //Create file stream.
                FileStream outputStream = new FileStream("../../../Output.pdf", FileMode.CreateNew);

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
