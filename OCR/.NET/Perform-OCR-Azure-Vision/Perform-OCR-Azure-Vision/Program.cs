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
                PdfLoadedDocument lDoc = new PdfLoadedDocument(Path.GetFullPath(@"Data/Region.pdf"));

                //Set OCR language.
                processor.Settings.Language = Languages.English;

                //Initialize the Azure vision OCR external engine.
                IOcrEngine azureOcrEngine = new AzureExternalOcrEngine();
                processor.ExternalEngine = azureOcrEngine;

                //Perform OCR.
                processor.PerformOCR(lDoc);

                //Save the document
                lDoc.Save(Path.GetFullPath(@"Output/Output.pdf"));

                //Close the document. 
                lDoc.Close(true);
            }
        }
    }
}
